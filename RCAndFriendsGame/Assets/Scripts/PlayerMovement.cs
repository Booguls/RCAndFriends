using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private StatSheet playerStats;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerStats = new StatSheet(20f, 2f);
        //playerStats.Health = 20f;
        //playerStats.Speed = 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 moveVector = Vector3.zero;
        if (horizontalMovement >= 0 && verticalMovement >= 0)
        {
            moveVector = new Vector3(horizontalMovement, 0f, 0f);
        }
        else if (horizontalMovement != 0) 
        {
            moveVector = new Vector3(horizontalMovement, 0f, -horizontalMovement);
        } 
        else if (verticalMovement != 0)
        {
            moveVector = new Vector3(verticalMovement, 0f, verticalMovement);
        }

        rigidBody.velocity = Vector3.Normalize(moveVector) * playerStats.Speed;
    }
}
