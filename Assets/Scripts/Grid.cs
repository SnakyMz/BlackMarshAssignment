using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] string gridDescription;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // For UI display
    public string GetDescription()
    {
        return transform.position.x + " : " + transform.position.z + " " + gridDescription;
    }

    public void ChangeDescription(string newDescription)
    {
        gridDescription = newDescription;
    }
}
