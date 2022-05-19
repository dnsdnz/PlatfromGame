using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target; //followed object
    public Vector3 offset;  //distance between target and camera
    public float lerpVal;
    
    //LateUpdate preferred ‘cos it runs after Update executions,
    //then it adjust the camera position smoothly with Lerp
    private void LateUpdate() 
    {
        Vector3 desiredPos = target.position + offset;  
        transform.position = Vector3.Lerp(transform.position,desiredPos,lerpVal); //returns a + (b-a) * t (t is lerpVal)
            //Lerp allows go from one point to another on a linear scale in a given time.
            //When lerpVal is closer to 1 or greater than 1, the position of camera will go directly to given position,
            //but if it is closer to 0, movement will slow down a bit and become smooth transition.
    }
}

