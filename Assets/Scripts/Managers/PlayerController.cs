using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Vector2 moveInput;
    public Vector2 lastMoveInput;
    public Vector3 spawnPos;

    private Rigidbody2D playerRb;

    //Hash References for Animator
    private Animator playerAnimController;

    private int MoveInputXHash = Animator.StringToHash("MoveInputX");
    private int MoveInputYHash = Animator.StringToHash("MoveInputY");
    private int isMovingHash = Animator.StringToHash("isMoving");

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();

        playerAnimController = GetComponentInChildren<Animator>();

    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        HandlePlayerAnimations();

        GetLastMoveInput();
    }

    private void HandlePlayerAnimations()
    {
        if (moveInput != Vector2.zero)
        {
            playerAnimController.SetFloat(MoveInputXHash, moveInput.x);
            playerAnimController.SetFloat(MoveInputYHash, moveInput.y);

            playerAnimController.SetBool(isMovingHash, true);
        }

        else
        {
            playerAnimController.SetBool(isMovingHash, false);
        }
    }

    private void GetLastMoveInput()
    {
        if (moveInput != Vector2.zero)
        {
            lastMoveInput = moveInput;
        }
    }
}
