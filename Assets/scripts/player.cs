using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float verticalSpeed = 5;
    public float horizontalSpeed = 10;
    private Rigidbody2D rb2d;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 velocity = rb2d.velocity;
        if (moveHorizontal == 0)
        {
            velocity.x = 0;
        }
        if (moveHorizontal > 0)
        {
            velocity.x = horizontalSpeed;
        }
        else if (moveHorizontal < 0)
        {
            velocity.x = -horizontalSpeed;
        }
        if (onGround() && moveVertical > 0)
        {
            velocity.y = verticalSpeed;
        }

        rb2d.velocity = velocity;
    }

    private bool onGround()
    {
        return rb2d.velocity.y == 0; // TODO: Replace with collision check. 
    }

}
