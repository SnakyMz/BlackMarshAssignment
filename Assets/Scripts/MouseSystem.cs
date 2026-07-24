using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseSystem : MonoBehaviour
{
    public static MouseSystem Instance { get; private set; }
    [SerializeField] LayerMask mouseLayerMask;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI unitNameText;
    [SerializeField] TextMeshProUGUI unitPositionText;

    Unit selectedUnit = null;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("There's more than one unit action system" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, mouseLayerMask))
        {
            // If we hover over a grid display description
            if (hit.collider.TryGetComponent<GridCube>(out GridCube gridCube))
            {
                descriptionText.text = gridCube.GetDescription();
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (hit.collider.TryGetComponent<Unit>(out Unit unit))
                {
                    SelectUnit(unit);
                }
            }
        }
    }

    void SelectUnit(Unit unit)
    {
        if (unit == selectedUnit) return;

        if (selectedUnit)
        {
            selectedUnit.ToggleSelectVisual(false);
        }
        selectedUnit = unit;
        selectedUnit.ToggleSelectVisual(true);
        UpdateUnitPanel();
    }

    void UpdateUnitPanel()
    {
        if (selectedUnit)
        {
            unitNameText.text = selectedUnit.name;
            unitPositionText.text = "Position " + selectedUnit.transform.position.x + " : " + selectedUnit.transform.position.z;
        }
        else
        {
            unitNameText.text = "Unit Name";
            unitPositionText.text = "Position 0 : 0";
        }
    }
}
