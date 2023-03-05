using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class RuntimeMovement : MonoBehaviour
{
    private InputSystemController input;
    private CharacterController characterController;
    private Transform cameraMain;
    [SerializeField] private Animator animator;
    [SerializeField] private float animationDampTime;
    private Transform playerTransform;
    [SerializeField] private float lerpRotationSpeed = 4f;


    private void Awake()
    {
        input = GetComponent<InputSystemController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        cameraMain = Camera.main.transform;
        playerTransform = transform;
    }

    private void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        Vector3 move = (cameraMain.forward * input.moveVal.y + cameraMain.right * input.moveVal.x);
        move.y = 0;
        characterController.Move(move * Time.deltaTime * input.moveSpeed);

        if (input.moveVal != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(playerTransform.localEulerAngles.x, cameraMain.localEulerAngles.y, playerTransform.localEulerAngles.z));
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, rotation, Time.deltaTime * lerpRotationSpeed);
        }
    }

    private void Animate()
    {
        animator.SetFloat("X", input.moveVal.x, animationDampTime, Time.deltaTime);
        animator.SetFloat("Y", input.moveVal.y, animationDampTime, Time.deltaTime);
    }
}
