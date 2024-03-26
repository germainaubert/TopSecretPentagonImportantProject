using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float jumpingForce = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float horizontal;
    private bool isFacingRight;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
        }

        Flip();
    }

    void FixedUpdate()
    {
        // x axis movement
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        if(!isFacingRight && horizontal <0f || isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("isGrounded == true");
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("isGrounded == false");
        isGrounded = false;
    }
}
