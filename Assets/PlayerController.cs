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
    float speed = 5f;
    float horizontalMovement;
    float multiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) animator.SetTrigger("jump");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (horizontalMovement != 0)
        {
            animator.SetBool("isRunning", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRb.AddForce(Vector2.right * horizontalMovement * speed * 1.5f);
                multiplier = 1.5f;
            }
            else
            {
                playerRb.AddForce(Vector2.right * horizontalMovement * speed);
                multiplier = 1f;
            }
                animator.SetFloat("multiplier", multiplier);
        }
        else if (playerRb.velocity.x < 0.1f) animator.SetBool("isRunning", false);


    }
}
