using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float mouseSpeed = 3;
    [SerializeField] float damp = 10;

    Vector3 localRot;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;

        //Get rotation input of the mouse * assigned mouse speed
        localRot.x += Input.GetAxis("Mouse X") * mouseSpeed;
        localRot.y -= Input.GetAxis("Mouse Y") * mouseSpeed;

        //Clamp to prevent the camera from going below the ground, or inverting over the player object
        localRot.y = Mathf.Clamp(localRot.y, -20f, 40f);

        //Apply quaternions, black magic fuckery happens here
        Quaternion qt = Quaternion.Euler(localRot.y, localRot.x, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, qt, Time.deltaTime * damp);
    }
}
