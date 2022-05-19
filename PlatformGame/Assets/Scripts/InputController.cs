using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance; //access this script from other scripts

    [HideInInspector] public bool isStarted, isTouched, isSwiping, swipeLeft, swipeRight, swipeUp, swipeDown; //movement status
    [HideInInspector] public Vector2 swipeDelta; //distances between current and touch positions
    [HideInInspector] public Vector2 startTouch; //first position of touch

    private const float deadZone = 100; //If deadzone increases, sensitivity increases(motion change captured with more detail)

    private void Awake()
    {
        Instance = this;
    }

//*********// Input.GetTouch(i).phase enum species for help to coding //*********
    //TouchPhase.Began --->>> Check is there any touch
    //TouchPhase.Stationary --->> There is touch but not move, it is stable
    //TouchPhase.Moved --->> There is touch and it is moving
    //TouchPhase.Ended --->> Touch stopped
    //TouchPhase.Canceled --->> If some problem about touch follow
//*********//                                                        //*********
    private void Update()
    {
        swipeLeft = swipeRight = swipeDown = swipeUp = false; //reset all data 

        #region Input Controls
        //for desktop
        if (Input.GetMouseButtonDown(0)) //left mouse button clicked
        {
            isStarted = true;
            isTouched = true;
            startTouch = Input.mousePosition; //first position of click
            if (Input.GetMouseButton(0)) //left mouse button clicked and held
            {
                isSwiping = true;
                startTouch = Input.mousePosition; //first position of click
            }
            else
            {
                isSwiping = false;
            }
        }
        else if (Input.GetMouseButtonUp(0)) //left click stopped
        {
            isTouched = false;
            isSwiping = false;
            startTouch = swipeDelta = Vector2.zero; //reset position when click stopped
        }
        //for mobile
        if (Input.touches.Length != 0) //if there is touch
        {
            if (Input.touches[0].phase == TouchPhase.Began) //screen touch start
            {
                isStarted = true;
                isTouched = true;
                isSwiping = false;
                startTouch = Input.mousePosition; //first position of touch
            }
            else if (Input.touches[0].phase == TouchPhase.Ended ||
                     Input.touches[0].phase == TouchPhase.Canceled) //screen touch done or there is a problem
            {
                isTouched = false;
                isSwiping = false;
                startTouch = swipeDelta = Vector2.zero; //reset position when touch stopped
            }
            else if (Input.touches[0].phase == TouchPhase.Stationary) //no movement but there is touch
            {
                isTouched = true;
                isSwiping = false;
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                isTouched = true;
                isSwiping = true;
            }
        }
        #endregion

        #region Calculate distances between current position and new touch position
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero) // if there is movement and touch
        {
            if (Input.touches.Length != 0) //for mobile
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0)) //for desktop
            {
                swipeDelta = (Vector2) Input.mousePosition - startTouch;
            }
        }
        #endregion

        #region Find direction of the movement
        if (isTouched) //there is touch
        {
            if (swipeDelta.magnitude > deadZone && isSwiping) //vector length greater than deadzone and swiping
            {
                float x = swipeDelta.x; //length of movement in x axis
                float y = swipeDelta.y; //length of movement in y axis

                if (Mathf.Abs(x) > Mathf.Abs(y)) //movement direction is left or right,
                    //calculate norm of the vectors with absolute value
                {
                    if (x < 0) //left
                    {
                        swipeLeft = true;
                    }
                    else //right
                    {
                        swipeRight = true;
                    }
                }
                else //movement direction is up or down
                {
                    if (y < 0) //down
                    {
                        swipeDown = true;
                    }
                    else //up
                    {
                        swipeUp = true;
                    }
                }
                startTouch = swipeDelta = Vector2.zero; //reset vectors in each calculation's end
            }
        }
        else //no touch so, character stops
        {
            isTouched = isSwiping = swipeLeft = swipeRight = swipeDown = swipeUp = false;
        }
        #endregion
    }
}