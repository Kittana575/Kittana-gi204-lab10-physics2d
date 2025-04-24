using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    
    
    Rigidbody2D rb2d;
    float move;
   [SerializeField] float speed;

   [SerializeField] float jumpForce;
   [SerializeField] bool isJumping;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb2d.AddForce(moveInput*speed);
        
        /*move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = (new Vector2(move * speed,rb2d.linearVelocity.y))*/;

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
