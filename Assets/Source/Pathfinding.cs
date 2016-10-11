using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour
{

    private Transform seeker;
    public Transform target;

    public bool debugShowPath = false;

    private GameGrid grid;
    private List<GridNode> renderPath;
    private Rigidbody2D rigidBody;

    public LayerMask mapCollider;


    private float distanceToTarget
    {
        get
        {
            if (seeker != null && target != null)
            {
                return Vector3.Distance(target.position, seeker.position);
            }
            else
            {
                return 0;
            }
        }

    }

    Vector3 checkPos;

    void Awake()
    {
        //grid = GetComponent<Grid> ();
        grid = GameObject.Find("Grid").GetComponent<GameGrid>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        seeker = this.transform;
        //mapCollider = LayerMask.NameToLayer("MapCollider");

    }

    void Update()
    {
        FindPath(seeker.position, target.position);
    }


    RaycastHit2D hit;

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        GridNode startNode = grid.NodeFromWorldPoint(startPos);
        GridNode targetNode = grid.NodeFromWorldPoint(targetPos);

        if (!targetNode.walkable) return; // don't look for the target if it's not in a walkable area

        List<GridNode> openSet = new List<GridNode>();
        HashSet<GridNode> closedSet = new HashSet<GridNode>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            GridNode node = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
                {
                    if (openSet[i].hCost < node.hCost)
                        node = openSet[i];
                }
            }

            openSet.Remove(node);
            closedSet.Add(node);

            if (node == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (GridNode neighbour in grid.GetNeighbours(node))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
                if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = node;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
    }

    void RetracePath(GridNode startNode, GridNode endNode)
    {
        List<GridNode> path = new List<GridNode>();
        GridNode currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        //grid.path = path;
        renderPath = path;

    }

    void OnDrawGizmos()
    {
        if (debugShowPath)
            if (renderPath != null && renderPath.Count > 0 && debugShowPath)
            {
                foreach (GridNode n in renderPath)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube((n.worldPoint), Vector3.one * (grid.nodeSize - .1f));
                }
            }

        //if (checkPos != null)
        //Gizmos.DrawCube(checkPos, Vector3.one * 0.6f);

    }


    int GetDistance(GridNode nodeA, GridNode nodeB)
    {
        // diagonal normal and dist usually 10 & 14

        const int distance_diagonal = 140000;
        const int distance_normal = 10; 

        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridZ - nodeB.gridZ);

        if (dstX > dstY)
            return distance_diagonal * dstY + distance_normal * (dstX - dstY);
        return distance_diagonal * dstX + distance_normal * (dstY - dstX);
    }
}
