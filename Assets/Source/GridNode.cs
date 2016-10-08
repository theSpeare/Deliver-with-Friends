using UnityEngine;
using System.Collections;

public class GridNode {

    public int gridX;
    public int gridZ;
    public Vector3 worldPoint;


    public int gCost;
    public int hCost;
    public GridNode parent;

    public bool walkable;
    public bool road;

    public GridNode(int _gridX, int _gridZ, Vector3 _worldPoint, bool _walkable = false)
    {
        gridX = _gridX;
        gridZ = _gridZ;
        worldPoint = _worldPoint;
        walkable = _walkable;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
