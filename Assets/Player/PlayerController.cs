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
    private CapsuleCollider2D cc;

    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        cc = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        // 좌우 이동
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 플립
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // 상태 변경
        if (Mathf.Abs(moveInput) > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        // 점프
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

        // 다운
        if (isGrounded && Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isDown", true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(PlayerTriggerOnOff());
            }
        }else
        {
            animator.SetBool("isDown", false);
        }
    }

    IEnumerator PlayerTriggerOnOff()
    {
        cc.isTrigger = true;
        float temp = rb.gravityScale;
        rb.gravityScale = 10;
        yield return new WaitForSeconds(0.5f);
        cc.isTrigger = false;
        rb.gravityScale = temp;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
