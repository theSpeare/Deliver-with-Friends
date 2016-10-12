using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugGridInspector : MonoBehaviour {

    public bool activated;

    private GridNode currentNode;
    private GameGrid grid;

    [SerializeField]
    private Text textDebug;

	// Use this for initialization
	void Start () {
        grid = GameObject.Find("Grid").GetComponent<GameGrid>();
        textDebug.text = activated?"DEBUG GRID INSPECTOR":"";
    }
	
	// Update is called once per frame
	void Update () {
        if (!activated)
            return;

        currentNode = grid.NodeFromWorldPoint(transform.position);
        textDebug.text = getNodeInformation(currentNode);
        dynamicColor();
        Debug.DrawLine(currentNode.worldPoint, currentNode.worldPoint + Vector3.up * 100, Color.red);
    }

    private void dynamicColor()
    {
        Material mat = this.GetComponent<MeshRenderer>().material;

        if (currentNode.walkable)
        {
            mat.color = Color.green;
        }
        else
        {
            mat.color = Color.red;
        }
    }

    private string getNodeInformation (GridNode n)
    {
        string display;

        display = "[GRID INSPECTOR]\n";
        display += "[x,z]: " + n.gridX + ", " + n.gridZ;
        display += "\n[worldPoint]: " + n.worldPoint.ToString();;
        display += "\n[walkable?]: " + n.walkable.ToString();

        return display;
    }
}
