using UnityEngine;
using UnityEditor;

public class GridTool : EditorWindow
{
    private GridSO gridSO;

    [MenuItem("Window/Grid Tool")]
    public static void ShowWindow()
    {
        GetWindow<GridTool>("Grid Tool");
    }

    private void OnGUI()
    {
        // false is to make sure it doesnt use any scene objects
        gridSO = (GridSO)EditorGUILayout.ObjectField("Grid SO", gridSO, typeof(GridSO), false);

        // Cant use the tool if empty
        if (gridSO == null)
        {
            EditorGUILayout.HelpBox("Assign a GridSO to start.", MessageType.Info);
            return;
        }

        // Draw 10x10 grid of buttons
        for (int y = 0; y < 10; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < 10; x++)
            {
                Vector2Int cell = new Vector2Int(x, y);

                bool alreadySelected = gridSO.ObstacleLocations.Contains(cell);
                GUIStyle style = new GUIStyle(GUI.skin.button);
                if (alreadySelected) style.normal.textColor = Color.red;

                if (GUILayout.Button($"{x},{y}", style, GUILayout.Width(30), GUILayout.Height(30)))
                {
                    if (!alreadySelected)
                    {
                        gridSO.ObstacleLocations.Add(cell);
                        EditorUtility.SetDirty(gridSO); // mark SO as changed
                    }
                    else
                    {
                        gridSO.ObstacleLocations.Remove(cell);
                        EditorUtility.SetDirty(gridSO);
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
