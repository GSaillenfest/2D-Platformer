using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    Rigidbody2D playerRb;
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField]
    float speed = 5f;

    float horizontalMovement;
    float multiplier = 1f;
    bool isFacingRight = true;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        Flip();
        isJumping = animator.GetBool("isJumping");

        if (Input.GetKeyDown(KeyCode.LeftControl)) animator.SetTrigger("dodge");

        if (!isJumping)
        {
            if (horizontalMovement < 0) isFacingRight = false;
            else if (horizontalMovement > 0) isFacingRight = true;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector2.up * jumpForce);
                animator.SetTrigger("jump");
                animator.SetBool("isJumping", true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (horizontalMovement != 0)
        {
            animator.SetBool("isRunning", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRb.AddForce(Vector2.right * horizontalMovement * speed * 2f);
                multiplier = 2f;
            }
            else
            {
                playerRb.AddForce(Vector2.right * horizontalMovement * speed);
                multiplier = 1f;
            }
            animator.SetFloat("multiplier", multiplier);
        }
        else animator.SetBool("isRunning", false);
    }

    void Flip()
    {
        if (!isFacingRight)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(-1f, 1f, 1f);
        }
        else GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 1f);
    }
}
