using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{

    public Transform target;
    public Transform startPoint;
    public float step;
    public float m_FOV;
    public float zoomSpeed;
    public Camera cam;
    float speed;

    private void onEnable()
    {
        startPoint = this.transform;
        m_FOV = 60;
    }
    void Update()
    {
        if (m_FOV <= 145.0f)
        {
            speed = step * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            m_FOV = m_FOV + (speed * zoomSpeed);
            cam.fieldOfView = m_FOV;

            transform.LookAt(target);
        }



        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        // transform.LookAt(target, Vector3.left);
    }

    // //movement speed in units per second
    // public float movementSpeed = 10f;
    // // public Vector3 pivotPoint = new Vector3(4f,4f,4f);

    // void Update()
    // {
    //     //get the Input from Horizontal axis
    //     float horizontalInput = Input.GetAxis("Horizontal");
    //     //get the Input from Vertical axis
    //     float verticalInput = Input.GetAxis("Vertical");
        
    //     //update the position
    //     transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0,  verticalInput * movementSpeed * Time.deltaTime);
    //     // Vector3 pivotPoint = new Vector3(0f,50f,0f);
    //     // transform.RotateAround(pivotPoint, Vector3.up, 90*Time.deltaTime);

    // }
}
