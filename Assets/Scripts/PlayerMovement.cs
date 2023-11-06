using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input axis
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position
        Vector2 newPosition = rb.position + Vector2.right * horizontalInput * speed * Time.deltaTime;

        // Update the object's position
        rb.MovePosition(newPosition);
    }
}
