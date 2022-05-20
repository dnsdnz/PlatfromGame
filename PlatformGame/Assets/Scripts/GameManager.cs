using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gamePlayPanel;
    public GameObject gamePlayObjects;

    [Header("Active Button Sprites")] public GameObject addBulletsActive;
    public GameObject doubleBulletsActive;
    public GameObject increaseFreqActive;
    public GameObject doubleBulletSpeedActive;
    public GameObject doubleCharSpeedActive;

    [Header("Passive Button Sprites")] public GameObject addBulletsPassive;
    public GameObject doubleBulletsPassive;
    public GameObject increaseFreqPassive;
    public GameObject doubleBulletSpeedPassive;
    public GameObject doubleCharSpeedPassive;

    //Bullet Status-> Active means player can press button and use power.
    //Passive means button power is using
    private bool isAddBulletsActive;
    private bool isDoubleBulletsActive;
    private bool isIncreaseFreqActive;
    private bool isDoubleBulletSpeedActive;
    private bool isDoubleCharSpeedActive;
    private int activePowerCount;

    private void Start()
    {
        isAddBulletsActive = isDoubleBulletsActive = isIncreaseFreqActive //all powers are available
            = isDoubleBulletSpeedActive = isDoubleCharSpeedActive = false; //not active so set false
        activePowerCount = 0;
    }

    private void Update()
    {
        if (CharacterController.Instance.isLevelFinish) //check the level is finished
        {
            BackToMenuButton(); //if finished, back to menu
        }
        else
        {
            if (activePowerCount <= 3) //if there are active powers less then 3 or 3, buttons can use
            {
                if (isAddBulletsActive)
                {
                    addBulletsPassive.SetActive(true); //open passive(button is not using) sprite
                    addBulletsActive.SetActive(false); //close active(button is not using) sprite
                }
                else
                {
                    addBulletsPassive.SetActive(false); //close passive(button is using) sprite
                    addBulletsActive.SetActive(true); //open active(button is  using) sprite
                }

                if (isDoubleBulletsActive)
                {
                    doubleBulletsPassive.SetActive(true);
                    doubleBulletsActive.SetActive(false);
                }
                else
                {
                    doubleBulletsPassive.SetActive(false);
                    doubleBulletsActive.SetActive(true);
                }

                if (isIncreaseFreqActive)
                {
                    increaseFreqPassive.SetActive(true);
                    increaseFreqActive.SetActive(false);
                }
                else
                {
                    increaseFreqPassive.SetActive(false);
                    increaseFreqActive.SetActive(true);
                }

                if (isDoubleBulletSpeedActive)
                {
                    doubleBulletSpeedPassive.SetActive(true);
                    doubleBulletSpeedActive.SetActive(false);
                }
                else
                {
                    doubleBulletSpeedPassive.SetActive(false);
                    doubleBulletSpeedActive.SetActive(true);
                }

                if (isDoubleCharSpeedActive)
                {
                    doubleCharSpeedPassive.SetActive(true);
                    doubleCharSpeedActive.SetActive(false);
                }
                else
                {
                    doubleCharSpeedPassive.SetActive(false);
                    doubleCharSpeedActive.SetActive(true);
                }
            }
            else  //active count is more then 3 so any button cant use
            {
                //if one of the active powers will close active count will be less then 3 so, activate again
               
            }
        }
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

    public void AddBulletsButton()
    {
        if (isAddBulletsActive) //if button is not activated, work button
        {
            isAddBulletsActive = false;
            activePowerCount--; //if active and press again decrease active powers
        }
        else //power is using so if press again, stop working
        {
            isAddBulletsActive = true;
            activePowerCount++; //if passive and usable, press again increase active powers
        }
    }

    public void DoubleBulletsButton()
    {
        if (isDoubleBulletsActive)
        {
            isDoubleBulletsActive = false;
            activePowerCount--;
        }
        else
        {
            isDoubleBulletsActive = true;
            activePowerCount++;
        }
    }

    public void IncreaseFrequencyButton()
    {
        if (isIncreaseFreqActive)
        {
            activePowerCount--;
            isIncreaseFreqActive = false;
            BulletController.Instance.fireRate = 0.5f; //shoot in every 1 second
        }
        else
        {
            activePowerCount++;
            isIncreaseFreqActive = true;
            BulletController.Instance.fireRate = 1; //shoot in every 2 second-default
        }
    }

    public void DoubleBulletSpeedButton()
    {
        if (isDoubleBulletSpeedActive)
        {
            activePowerCount--;
            isDoubleBulletSpeedActive = false;
            BulletController.Instance.bulletSpeed *= 2f; //double bullet speed
        }
        else
        {
            activePowerCount++;
            isDoubleBulletSpeedActive = true;
            BulletController.Instance.bulletSpeed /= 2f; //default bullet speed
        }
    }

    public void DoublePlayerSpeedButton()
    {
        if (isDoubleCharSpeedActive)
        {
            activePowerCount--;
            isDoubleCharSpeedActive = false;
            CharacterController.Instance.speed *= 2f; //double character speed
        }
        else
        {
            activePowerCount++;
            isDoubleCharSpeedActive = true;
            CharacterController.Instance.speed /= 2f; //default character speed
        }
    }

    #endregion
}