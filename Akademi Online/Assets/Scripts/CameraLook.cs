using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform target; // the object to look at
    public float speed; // the camera's movement speed

    // Update is called once per frame
    void Update()
    {
        // calculate the new position for the camera
        Vector3 newPosition = target.position + new Vector3(0f, 2f, -5f);

        // move the camera to the new position
        transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);

        // make the camera look at the target object
        transform.LookAt(target);
    }
}
