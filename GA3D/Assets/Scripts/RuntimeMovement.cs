using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class RuntimeMovement : MonoBehaviour
{
    private InputSystemController input;
    private CharacterController characterController;
    [SerializeField] private Animator animator;
    [SerializeField] private float animationDampTime;

    private void Awake()
    {
        input = GetComponent<InputSystemController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        characterController.Move(new Vector3(input.moveVal.x * input.moveSpeed * Time.deltaTime, 0f, input.moveVal.y * input.moveSpeed * Time.deltaTime));
    }

    private void Animate()
    {
        animator.SetFloat("X", characterController.velocity.x, animationDampTime, Time.deltaTime);
        animator.SetFloat("Y", characterController.velocity.z, animationDampTime, Time.deltaTime);
    }
}
