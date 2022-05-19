using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   public float speed;  //character's speed
   public Rigidbody rb; //character's rigidbody from editor
   private bool isMoving; //is character moving

   //FixedUpdate preferred‘cos it runs at a fixed interval related to game’s frame rate,
   //making it possible to run once, zero, or multiple times per frame but Update runs exactly once every frame.
   //Physics related functions need has to be sure and proper and physics engine also runs on the same interval as the FixedUpdate.

   private void FixedUpdate()  //check movement directions
   {
      if (Input.GetKeyDown(KeyCode.LeftArrow) || InputController.Instance.swipeLeft)
      {
         rb.velocity = Vector3.left * speed * Time.deltaTime;  //V3(-1,0,0)
      }
      else if (Input.GetKeyDown(KeyCode.RightArrow) || InputController.Instance.swipeRight)
      {
         rb.velocity = Vector3.right * speed * Time.deltaTime; //V3(1,0,0)
      }
      else if (Input.GetKeyDown(KeyCode.UpArrow) || InputController.Instance.swipeUp)
      {
         rb.velocity = Vector3.forward * speed * Time.deltaTime;  //V3(0,0,1)
      }
      else if (Input.GetKeyDown(KeyCode.DownArrow) || InputController.Instance.swipeDown)
      {
         rb.velocity = -Vector3.forward * speed * Time.deltaTime;    //V3(0,0,-1)
      }
   }
}