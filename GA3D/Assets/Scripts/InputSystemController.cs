using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public Vector2 moveVal;
    public float moveSpeed;

    public void Movement(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            moveVal = value.ReadValue<Vector2>();
        }
        if(value.canceled)
        {
            moveVal = value.ReadValue<Vector2>();
        }
    }
}
