using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GridSO gridSO;
    [SerializeField] GameObject obstaclePrefab;

    Dictionary<Vector2Int, GridNode> gridNodes = new Dictionary<Vector2Int, GridNode>();

    void Awake()
    {
        gridNodes.Clear();

        // Registering all gridcubes
        foreach (Transform child in transform)
        {
            Vector2Int gridPosition = new(
                Mathf.RoundToInt(child.position.x),
                Mathf.RoundToInt(child.position.z)
            );
            bool isWalkable = true;

            if (!gridNodes.ContainsKey(gridPosition))
            {
                gridNodes.Add(gridPosition, new GridNode(child.gameObject, gridPosition, isWalkable));
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Vector2Int position in gridSO.ObstacleLocations)
        {
            SpawnObstacle(position);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle(Vector2Int position)
    {
        if (gridNodes.TryGetValue(position, out GridNode gridNode))
        {
            gridNode.isWalkable = false;
            gridNode.gridCube.GetComponent<GridCube>().ChangeDescription("Obstacle");
        }
        Vector3 spawnLocation = new Vector3(position.x, obstaclePrefab.transform.position.y, position.y);
        Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity, transform);
    }
}
