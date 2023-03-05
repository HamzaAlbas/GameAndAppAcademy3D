using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class RuntimeMovement : MonoBehaviour
{
    private InputSystemController input;
    private CharacterController characterController;

    private void Awake()
    {
        input = GetComponent<InputSystemController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        characterController.Move(new Vector3(input.moveVal.x * input.moveSpeed * Time.deltaTime, 0f, input.moveVal.y * input.moveSpeed * Time.deltaTime));
    }
}
