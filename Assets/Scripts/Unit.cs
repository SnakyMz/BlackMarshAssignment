using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] GameObject selectVisual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ToggleSelectVisual(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleSelectVisual(bool state)
    {
        selectVisual.SetActive(state);
    }
}
