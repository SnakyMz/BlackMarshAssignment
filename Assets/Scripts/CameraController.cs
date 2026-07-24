using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 100f;

    Vector2 moveInput;
    float rotateInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // WASD camera movement
        Vector3 inputDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
        transform.position += inputDirection * moveSpeed * Time.deltaTime;

        // QE camera rotation
        Vector3 rotateDirection = new Vector3(0, rotateInput, 0);
        transform.eulerAngles += rotateDirection * rotateSpeed * Time.deltaTime;
    }

    // Getting Inputs via Unity Events
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotateInput = context.ReadValue<float>();
    }
}
