using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public Vector2 moveVal;
    public Vector2 lookVal;
    public float moveSpeed;
    public float lookSpeed = 100.0f;

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

    public void Look(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            lookVal = value.ReadValue<Vector2>()*Time.deltaTime*lookSpeed;
        }
        if(value.canceled)
        {
            lookVal = Vector2.zero;
        }
    }
}
