using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private StatSheet playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats.Health = 20f;
        playerStats.Speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
