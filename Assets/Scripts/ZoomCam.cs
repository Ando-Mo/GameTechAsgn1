using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{

    public Transform target;
    public Transform startPoint;
    public Transform target2;
    public float step;
    public float m_FOV;
    public float zoomSpeed;
    public Camera cam;
    float speed;

    public bool movingForward;

    public void Awake()
    {
        print("camera enabled");
        startPoint = this.transform;
        m_FOV = 60;
        movingForward = true;
    }

    void Update()
    {
        if (m_FOV <= 145.0f && movingForward)
        {
            print("moving forward");
            speed = step * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            m_FOV = m_FOV + (speed * zoomSpeed);
            cam.fieldOfView = m_FOV;

            transform.LookAt(target);
        }
        else if (m_FOV > 145.0f)
        {
            movingForward = false;
            print("start moving backwards");
        }

        if (m_FOV <= 60)
        {
            movingForward = true;
            transform.position = startPoint.position;
        }

        if (movingForward == false)
        {
            print("now moving backwards");
            speed = step * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);

            m_FOV = m_FOV - (speed * zoomSpeed);
            cam.fieldOfView = m_FOV;

            //transform.LookAt(target2);
        }
        




        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        // transform.LookAt(target, Vector3.left);
    }
}
