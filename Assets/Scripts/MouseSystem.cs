using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseSystem : MonoBehaviour
{
    [SerializeField] LayerMask mouseLayerMask;
    [SerializeField] TextMeshProUGUI descriptionText;

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
            if (hit.transform.TryGetComponent<Grid>(out Grid grid))
            {
                descriptionText.text = grid.GetDescription();
            }
        }
        else
        {
            descriptionText.text = "";
        }
    }
}
