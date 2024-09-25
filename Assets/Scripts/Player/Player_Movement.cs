using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// This class is responsible for managing the movement and jumping of the character.
/// </summary>
public class Player_Movement : MonoBehaviour
{

    [SerializeField] Rigidbody2D Rigidbody;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AnimatorOptimazation_HashCode animator_Optimazation_HashCode;
    void FixedUpdate()
    {
        Movement();
        Jump();
    }

    #region Movement
    [Space(12)]
    [Header("----Movement Properties----")]
    [SerializeField] float moveSpeed = 5f;

    float horizontalInput;
    Vector2 movement;
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        movement = new Vector2(horizontalInput, 0f);
        //Rigidbody.velocity = new Vector2(movement.x * moveSpeed, Rigidbody.velocity.y);   
        //Rigidbody.AddForce(new Vector2(movement.x * moveSpeed, 0), ForceMode2D.Force);
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);

        RunAnimation();
    }

    void RunAnimation()
    {

        if (movement.magnitude > 0)
        {
            animator.SetBool(animator_Optimazation_HashCode.ID_IsRuning, true);
            if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            animator.SetBool(animator_Optimazation_HashCode.ID_IsRuning, false);
        }
    }
    #endregion

    #region Jump
    [Space(20)]
    [Header("----Jump Properties----")]
    [SerializeField] float jumpForce = 10f;

    [SerializeField] Vector2 OverlapCircle_Position;
    [SerializeField] LayerMask OverlapCircle_LayerMask;
    [SerializeField] float Radus;
    Vector2 Pos;
    bool IsOnGround;
    void Jump()
    {
        Pos = new Vector2(transform.position.x, transform.position.y);
        IsOnGround = Physics2D.OverlapCircle(Pos - OverlapCircle_Position, Radus, OverlapCircle_LayerMask);
        if (IsOnGround == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                print("Jump");
            }
        }
        JumpAnimation();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position - (new Vector3(OverlapCircle_Position.x, OverlapCircle_Position.y, 0)), Radus);
    }

    void JumpAnimation()
    {
        if (IsOnGround == true)
        {
            animator.SetBool(animator_Optimazation_HashCode.ID_Jump, false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }
    }
    #endregion
}
