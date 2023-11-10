using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float shotForce = 50.0f;
 
    private Rigidbody2D rb;
    private Collider2D c2D;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
        // Handle player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0) * moveSpeed;
        

        // Apply movement to the player
        if (IsGrounded())
        {
            rb.velocity = new Vector2(movement.x, rb.velocity.y);
        }

        // Check for jump input
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        // Check for dashing input
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        //move physics calculations here? best practice
    }

    private void Jump()
    {
        // Apply an upward force for jumping
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        // Calculate the direction from the player to the mouse cursor
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = (mousePos - transform.position).normalized;

        // Apply a force in the direction opposite to the mouse cursor
        rb.AddForce(-shootDirection * shotForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return c2D.IsTouchingLayers(LayerMask.GetMask("Environment")); //Can also use .IsTouchingLayera(LayerMask.GetMask("Environment"))
    }
}
