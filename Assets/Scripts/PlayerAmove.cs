using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmove : MonoBehaviour
{
    public static float maxspeed;
    Rigidbody2D rigid;
    public float jumpForce = 5f;
    private bool isGounded;
    SpriteRenderer spriteRenderer;
    Animator animator;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        maxspeed = 5f;
    }
    void Update()
    {
        if (Input.GetButtonDown("Up") && !animator.GetBool("IsJumping"))
        {
            Jump();
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-5, 5, 5);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(5, 5, 5);
        }

        if (Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if(rigid.velocity.x > maxspeed)
        {
            rigid.velocity = new Vector2(maxspeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxspeed*(-1))
        {
            rigid.velocity = new Vector2(maxspeed*(-1), rigid.velocity.y);
        }

        if (rigid.velocity.y < 0){
            Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 2, LayerMask.GetMask("ground"));
            if(rayHit.collider != null){
                if(rayHit.distance < 1.2f)
                    animator.SetBool("IsJumping", false);
            }
        }
    }
    void Jump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
