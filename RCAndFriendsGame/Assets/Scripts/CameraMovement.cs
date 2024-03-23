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

        localRot.x += Input.GetAxis("Mouse X") * mouseSpeed;
        localRot.y -= Input.GetAxis("Mouse Y") * mouseSpeed;

        localRot.y = Mathf.Clamp(localRot.y, -20f, 40f);

        Quaternion qt = Quaternion.Euler(localRot.y, localRot.x, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, qt, Time.deltaTime * damp);
    }
}
