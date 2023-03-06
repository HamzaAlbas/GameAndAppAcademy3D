using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private CharacterController characterController;
    private Transform cameraMain;
    private Transform playerTransform;
    private Vector3 playerVelocity;
    [SerializeField] private Animator animator;

    [SerializeField] private float animationDampTime;
    [SerializeField] private float lerpRotationSpeed = 4f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float playerSpeed = 5f;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }

    private void Start()
    {
        cameraMain = Camera.main.transform;
        playerTransform = transform;
    }

    private void Update()
    {
        Vector2 movementInput = playerInputs.PlayerControls.Movement.ReadValue<Vector2>();
        Vector3 move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        move.y = gravityValue;  
        characterController.Move(move * Time.deltaTime * playerSpeed);

        if (playerInputs.PlayerControls.Jump.triggered)
        {
            move.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetTrigger("jump");
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);

        if (movementInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(playerTransform.localEulerAngles.x, cameraMain.localEulerAngles.y, playerTransform.localEulerAngles.z));
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, rotation, Time.deltaTime * lerpRotationSpeed);
        }

        animator.SetFloat("X", movementInput.x, animationDampTime, Time.deltaTime);
        animator.SetFloat("Y", movementInput.y, animationDampTime, Time.deltaTime);
        animator.SetBool("isGrounded", characterController.isGrounded);
    }
}
