using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridSO", menuName = "Scriptable Objects/GridSO")]
public class GridSO : ScriptableObject
{
    public List<Vector2Int> ObstacleLocations;
}
