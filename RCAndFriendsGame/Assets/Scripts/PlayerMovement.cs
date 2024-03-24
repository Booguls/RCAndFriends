using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private StatSheet playerStats;
    private bool onGround = true;

    private float horizInput;
    private float vertInput;

    [SerializeField] private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        //Set player rigidbody to one attached to game object's, similar for stats.
        rigidBody = GetComponent<Rigidbody>();
        playerStats = new StatSheet(20f, 5f, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get camera's forward position, will change with player's camera control
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        //Reset y variables to prevent vector miscalculations
        camForward.y = 0;
        camRight.y = 0;

        //Create a move vector, resulted by multiplying vertical input with camera's forward and similar for horizontal movement
        Vector3 moveVector = vertInput * camForward + horizInput * camRight;
        moveVector = moveVector.normalized * playerStats.Speed;

        //Insert basic condition for player running, set to shift for now
        //TODO: Explore generalization of shift key input.
        /*
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveVector *= 2;
            moveVector.x *= 2;
            moveVector.y *= 2;
        }
        */

        //Movement result occurs here
        rigidBody.velocity = new Vector3(moveVector.x, rigidBody.velocity.y, moveVector.z);
    }

    //Separated from FixedUpdate function to more reliably capture user input
    void Update()
    {
        //Get user input
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        //Get input when user presses space and jumps
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            //Apply jump force as an impulse
            rigidBody.AddForce(new Vector3(rigidBody.velocity.x, playerStats.Jump, rigidBody.velocity.z), ForceMode.Impulse);
            onGround = false;
        }
    }

    //Collision detection function
    void OnCollisionStay(Collision collision)
    {
        //Check if object collided with is terrain, if so player made contact with ground and can jump again
        if (collision.gameObject.tag == "terrain")
        {
            foreach (ContactPoint contactPoint in collision.contacts)
            {
                if (contactPoint.normal.x != 0f)
                {
                    onGround = false;
                }
                else if (contactPoint.normal.y > 0)
                {
                    onGround = true;
                }
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            onGround = false;
        }
    }
}
