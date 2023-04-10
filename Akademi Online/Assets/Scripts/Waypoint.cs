using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 10f;
    private int waypointIndex = 0;

    void FixedUpdate()
    {
        if (waypointIndex < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].position)
            {
                waypointIndex++;
            }
        }
    }


}

    

