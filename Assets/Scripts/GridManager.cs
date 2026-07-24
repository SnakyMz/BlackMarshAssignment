using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GridSO gridSO;
    [SerializeField] GameObject obstaclePrefab;

    // Dictionary<Vector2Int, GameObject> gridCubes = new Dictionary<Vector2Int, GameObject>();

    void Awake()
    {
        // BuildDictionary();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Vector2Int location in gridSO.ObstacleLocations)
        {
            SpawnObstacle(location);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // void BuildDictionary()
    // {
    //     gridCubes.Clear();

    //     // Since this is attached to Grids which is parent to all Grid cubes
    //     foreach (Transform child in transform)
    //     {
    //         Vector2Int gridPosition = new(
    //             Mathf.RoundToInt(child.position.x),
    //             Mathf.RoundToInt(child.position.z)
    //         );

    //         if (!gridCubes.ContainsKey(gridPosition))
    //         {
    //             gridCubes.Add(gridPosition, child.gameObject);
    //         }
    //     }
    // }

    void SpawnObstacle(Vector2Int location)
    {
        // if (gridCubes.TryGetValue(location, out GameObject gridCube)) return;
        Vector3 spawnLocation = new Vector3(location.x, obstaclePrefab.transform.position.y, location.y);
        Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity, transform);
    }
}
