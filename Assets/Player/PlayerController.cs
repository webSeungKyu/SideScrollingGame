using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 6f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private Transform groundCheck;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
    }

    void Update()
    {
        // �¿� �̵�
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // �ø�
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // ���� ����
        if (Mathf.Abs(moveInput) > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        // ����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }

        // �ٿ�
        if (isGrounded && Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isDown", true);
        }else
        {
            animator.SetBool("isDown", false);
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
