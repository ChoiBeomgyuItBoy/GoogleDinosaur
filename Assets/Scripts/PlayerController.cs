using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode jumpKey;
    [SerializeField] float jumpForce = 3;
    [SerializeField] float gravityMultiplier = 2;
    [SerializeField] UnityEvent onJump;
    [SerializeField] UnityEvent onDie;
    CharacterController controller;
    Animator animator;
    float verticalVelocity = 0;

    public void Kill()
    {
        onDie?.Invoke();
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ApplyGravity();

        if(Input.GetKey(jumpKey))
        {
            Jump();
        }

        if(controller.isGrounded)
        {
            Land();
        }
    }

    void ApplyGravity()
    {
        if(controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }

        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    void Jump()
    {
        if(controller.isGrounded)
        {
            onJump?.Invoke();
            verticalVelocity += jumpForce;
        }

        animator.SetTrigger("onJump");
        animator.ResetTrigger("onLand");
    }

    void Land()
    {
        animator.SetTrigger("onLand");
        animator.ResetTrigger("onJump");
    }
}
