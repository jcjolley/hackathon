using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float verticalSpeed = 5;
    public float horizontalSpeed = 10;
    private bool jumping = false;
    private float lastHorizontal = 0;
    private Rigidbody2D rb2d;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 velocity = rb2d.velocity;
        if (System.Math.Abs(moveHorizontal) < System.Math.Abs(lastHorizontal))
        {
            print("Stop");
            velocity.x = 0;
        }
        if (moveHorizontal > 0)
        {
            velocity.x = horizontalSpeed;
        } else if (moveHorizontal < 0)
        {
            velocity.x = -horizontalSpeed;
        }
        lastHorizontal = moveHorizontal;
        
        if (moveVertical > 0)
        {
            if (!jumping)
            {
                velocity.y = verticalSpeed;
                jumping = true;
            }
        }
        if (rb2d.velocity.y == 0)
        {
            jumping = false;
        }
        rb2d.velocity = velocity;
    }
    
    void FixedUpdate()
    {
        
    }
}
