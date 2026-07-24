using UnityEngine;

public class GridCube : MonoBehaviour
{
    [SerializeField] string description;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetDescription()
    {
        return transform.position.x + " : " + transform.position.z + "\n" + description;
    }

    public void ChangeDescription(string newDescription)
    {
        description = newDescription;
    }
}
