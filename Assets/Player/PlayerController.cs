using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Idle, Move
}
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float inputX;
    public float inputY;
    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        speed = 3f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        MoveX();
    }

    /// <summary>
    /// 좌우이동
    /// </summary>
    void MoveX()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if (inputX > 0)
        {
            ChangeAnimator("Move");
            rb.velocity = Vector2.right * speed;
            
        }
        else if (inputX < 0)
        {
            ChangeAnimator("Move");
            rb.velocity = Vector2.left * speed;
        }
        else
        {
            ChangeAnimator("");
            rb.velocity = Vector2.zero;
        }
    }

    /// <summary>
    /// 애니메이션 변경[Move, ]
    /// </summary>
    /// <param name="motion">없다면 Idle</param>
    void ChangeAnimator(string motion)
    {
        switch (motion)
        {
            case "Move":
                animator.SetBool("Move", true); break;

            default: animator.SetBool("Move", false); break;
        }
        
    }
}
