using UnityEngine;

public class GridNode
{
    public GameObject gridCube;
    public Vector2Int position;
    public bool isWalkable;
    public GridNode parent;
    public int gCost;
    public int hCost;
    public int fCost => gCost + hCost;

    public GridNode(GameObject gridCube, Vector2Int position, bool isWalkable)
    {
        this.gridCube = gridCube;
        this.position = position;
        this.isWalkable = isWalkable;
    }
}
