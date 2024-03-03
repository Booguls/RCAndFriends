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
        //rigidBody = GetComponent<Rigidbody>();
        playerStats = new StatSheet();
        playerStats.Health = 20f;
        playerStats.Speed = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Console.WriteLine(horizontalMovement + " " + verticalMovement);

        if (horizontalMovement > 0)
        {
            
        }
    }
}
