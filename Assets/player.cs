using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float verticalSpeed = 10; //Floating point variable to store the player's movement speed.
    public float horizontalSpeed = 2;
    public float maxHorizontalSpeed = 100;
    public Vector2 movement;
    public bool isJump = false;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical;
        //Store the current vertical input in the float moveVertical.

        if(!isJump)
        {
            moveVertical = Input.GetAxis("Vertical");
            isJump = true;
        } else
        {
            moveVertical = 0;
        }
      
        if(isJump && rb2d.velocity.y == 0)
        {
            isJump = false;
        }         

        if (System.Math.Abs(rb2d.velocity.x) > maxHorizontalSpeed)
        {
            moveHorizontal = 0;
        } 

        //Use the two store floats to create a new Vector2 variable movement.
        movement = new Vector2(moveHorizontal * horizontalSpeed, moveVertical * verticalSpeed);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        print("Movement is:" + movement);
        rb2d.AddForce(movement);
        
    }
}
