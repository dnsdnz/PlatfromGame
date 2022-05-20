using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gamePlayPanel;
    public GameObject gamePlayObjects;
    
    [Header("Active Button Sprites")] 
    public GameObject addBulletsActive;
    public GameObject doubleBulletsActive;
    public GameObject increaseFreqActive;
    public GameObject doubleBulletSpeedActive;
    public GameObject doubleCharSpeedActive;
    
    [Header("Passive Button Sprites")] 
    public GameObject addBulletsPassive;
    public GameObject doubleBulletsPassive;
    public GameObject increaseFreqPassive;
    public GameObject doubleBulletSpeedPassive;
    public GameObject doubleCharSpeedPassive;

    //Bullet Status
    private bool isAddBulletsActive;
    private bool isDoubleBulletsActive;
    private bool isIncreaseFreqActive;
    private bool isDoubleBulletSpeedActive;
    private bool isDoubleCharSpeedActive;
    private int activePowerCount;
    private void Start()
    {
        isAddBulletsActive = isDoubleBulletsActive = isIncreaseFreqActive =
            isDoubleBulletSpeedActive = isDoubleCharSpeedActive = false;
        activePowerCount = 0;
    }

    private void Update()
    {
        // if (activePowerCount > 3)
        // {
        //     isAddBulletsActive = isDoubleBulletsActive = isIncreaseFreqActive
        //         = isDoubleBulletSpeedActive = isDoubleCharSpeedActive = false;
        // }
        Debug.Log(activePowerCount);
    }

    public void StartGameButton()
    {
        InputController.Instance.startTouch = Vector2.zero; //reset position when game start
        InputController.Instance.swipeDelta = Vector2.zero; //reset distance when game start
        menuPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        gamePlayObjects.SetActive(true);
    }

    public void BackToMenuButton()
    {
        menuPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        gamePlayObjects.SetActive(false);
        InputController.Instance.isTouched = false; //stop character when back to menu
    }

    #region Special Power Buttons
    // private void ButtonActivityController()
    // {
    //     if (isAddBulletsActive)
    //     {
    //         addBulletsActive.SetActive(true);
    //         addBulletsPassive.SetActive(false);
    //     }
    //     else if (isDoubleBulletsActive)
    //     {
    //         doubleBulletsActive.SetActive(true);
    //         doubleBulletsPassive.SetActive(false);
    //     }
    //     else if (isIncreaseFreqActive)
    //     {
    //         increaseFreqActive.SetActive(true);
    //         increaseFreqPassive.SetActive(false);
    //     }
    //     else if (isDoubleBulletSpeedActive)
    //     {
    //         doubleBulletSpeedActive.SetActive(true);
    //         doubleBulletSpeedActive.SetActive(false);
    //     }
    //     else if (isDoubleCharSpeedActive)
    //     {
    //         doubleCharSpeedActive.SetActive(true);
    //         doubleCharSpeedPassive.SetActive(false);
    //         activePowerCount++;
    //     }
    // }
    public void AddBulletsButton()
    {
        if (!isAddBulletsActive) //if button is not activated, work button
        {
            addBulletsPassive.SetActive(true); //open passive(button is using) sprite
            addBulletsActive.SetActive(false); //close active(button is not using) sprite
        }
        else
        {
            activePowerCount++;  //count active powers
            addBulletsPassive.SetActive(false); 
            addBulletsActive.SetActive(true);
        }   
    }

    public void DoubleBulletsButton()
    {
        if (!isDoubleBulletsActive)
        {
            doubleBulletsPassive.SetActive(true);
            doubleBulletsActive.SetActive(false);
        }
        else
        {
            activePowerCount++;
            doubleBulletsPassive.SetActive(false);
            doubleBulletsActive.SetActive(true);
        }   
    }

    public void IncreaseFrequencyButton()
    {
        if (!isIncreaseFreqActive)
        {
            BulletController.Instance.fireRate = 0.5f; //shoot in every 1 second
            increaseFreqPassive.SetActive(true);
            increaseFreqActive.SetActive(false);
        }
        else
        {
            activePowerCount++;
            BulletController.Instance.fireRate = 1;  //shoot in every 2 second
            increaseFreqPassive.SetActive(false);
            increaseFreqActive.SetActive(true);
        }
    }

    public void DoubleBulletSpeedButton()
    {
        if (!isDoubleBulletSpeedActive)
        {
            BulletController.Instance.bulletSpeed *= 2f; //double bullet speed
            doubleBulletSpeedActive.SetActive(true);
            doubleBulletSpeedPassive.SetActive(false);
        }
        else
        {
            activePowerCount++;
            BulletController.Instance.bulletSpeed *= 2f; //default bullet speed
            doubleBulletSpeedActive.SetActive(false);
            doubleBulletSpeedPassive.SetActive(true);
        }   
    }

    public void DoublePlayerSpeedButton()
    {
        if (!isDoubleCharSpeedActive)
        {
            CharacterController.Instance.speed *= 2f; //double character speed
            doubleCharSpeedActive.SetActive(true);
            doubleCharSpeedPassive.SetActive(false);
        }
        else
        {
            activePowerCount++;
            CharacterController.Instance.speed *= 1f; //default character speed
            doubleCharSpeedActive.SetActive(false);
            doubleCharSpeedPassive.SetActive(true);
        }  
    }
    #endregion
}