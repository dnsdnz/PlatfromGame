using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance; //access this script from other scripts
    public float speed; //character's speed
    public Rigidbody rb; //character's rigidbody from editor
    private void Awake()
    {
        Instance = this;
    }

    //FixedUpdate preferred‘cos it runs at a fixed interval related to game’s frame rate,
    //making it possible to run once, zero, or multiple times per frame but Update runs exactly once every frame.
    //Physics related functions need has to be sure and proper and physics engine also runs on the same interval as the FixedUpdate.
    private void FixedUpdate() //check movement directions
    {
        if (InputController.Instance.isTouched && InputController.Instance.isSwiping)  //touch and movement
        {
            if (InputController.Instance.swipeLeft)
            {
                rb.velocity = Vector3.left * speed * Time.deltaTime; //V3(-1,0,0)
            }
            else if (InputController.Instance.swipeRight)
            {
                rb.velocity = Vector3.right * speed * Time.deltaTime; //V3(1,0,0)
            }
            // else if (InputController.Instance.swipeUp)       //no need for up and down
            // {
            //     rb.velocity = Vector3.forward * speed * Time.deltaTime; //V3(0,0,1)
            // }
            // else if (InputController.Instance.swipeDown)
            // {
            //     rb.velocity = -Vector3.forward * speed * Time.deltaTime; //V3(0,0,-1)
            // }
        }
        else if (InputController.Instance.isTouched && !InputController.Instance.isSwiping)  //touch and no movement
        {
            rb.velocity = Vector3.forward * speed * Time.deltaTime;  //only move forward, no swipe
        }
        else if (!InputController.Instance.isTouched)  //no touch
        {
            rb.velocity = Vector3.zero;  //stop character
        }
    }
    private void OnCollisionEnter (Collision col) //detect finish collider
    {
        if (col.gameObject.tag == "Finish")
        {
            Debug.Log("hit");
            InputController.Instance.isTouched = false;  //stop character when finish
        }
    }
}