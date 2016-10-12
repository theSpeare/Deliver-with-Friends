using UnityEngine;
using System.Collections;

public class GridNode {

    public int gridX;
    public int gridZ;
    public Vector3 worldPoint;
    
    public bool walkable;
    public bool road;

    public PathfindingInfo pathfinding;

    public GridNode(int _gridX, int _gridZ, Vector3 _worldPoint, bool _walkable)
    {
        gridX = _gridX;
        gridZ = _gridZ;
        worldPoint = _worldPoint;
        walkable = _walkable;
    }


    public class PathfindingInfo
    {
        public int gCost;
        public int hCost;
        public GridNode parent;

        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }
    }
}
