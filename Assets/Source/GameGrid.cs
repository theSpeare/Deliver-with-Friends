using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameGrid : MonoBehaviour {

    private GridNode[,] grid;
    public float nodeSize;
    public float nodeSizeHalf
    {
        get
        {
            return nodeSize / 2;
        }
    }
    int gridSizeX, gridSizeZ;
    public Vector3 gridWorldSize;

    [SerializeField]
    private LayerMask roadMask;

    void Awake () {
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeSize);
        gridSizeZ = Mathf.RoundToInt(gridWorldSize.z / nodeSize);
        createGrid();

        Debug.Log("GRID NODE COUNT x: " + grid.GetLength(0) + ", z: " + grid.GetLength(1));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.z));
        if (grid != null)
            foreach (GridNode node in grid)
            {
                Gizmos.color = Color.green;
                if (node.walkable)
                    Gizmos.color = Color.blue;
                Gizmos.DrawWireCube(node.worldPoint, new Vector3(0.4f,0,0.4f));
            }
    }


    private void createGrid()
    {
        grid = new GridNode[gridSizeX, gridSizeZ];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.z / 2;


        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeSize + nodeSizeHalf) + Vector3.forward * (z * nodeSize + nodeSize / 2);

                
                bool isRoad = (Physics.CheckSphere(worldPoint, nodeSize/3, roadMask));

                grid[x, z] = new GridNode(x, z, worldPoint, isRoad);
            }
        }

    }

    public GridNode NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentZ = (worldPosition.z + gridWorldSize.z / 2) / gridWorldSize.z;
        percentX = Mathf.Clamp01(percentX);
        percentZ = Mathf.Clamp01(percentZ);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int z = Mathf.RoundToInt((gridSizeZ - 1) * percentZ);
        return grid[x, z];
    }

    public List<GridNode> GetNeighbours(GridNode node)
    {
        List<GridNode> neighbours = new List<GridNode>();

        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (x == 0 && z == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkZ = node.gridZ + z;

                if (checkX >= 0 && checkX < gridSizeX && checkZ >= 0 && checkZ < gridSizeZ)
                {
                    neighbours.Add(grid[checkX, checkZ]);
                }
            }
        }

        return neighbours;
    }
}
