using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gamePlayPanel;
    public GameObject gamePlayObjects;
    public void StartGameButton()
    {
        InputController.Instance.startTouch = Vector2.zero;  //reset position when game start
        InputController.Instance.swipeDelta = Vector2.zero;  //reset distance when game start
        menuPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        gamePlayObjects.SetActive(true);
    }
    public void BackToMenuButton()
    {
        menuPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        gamePlayObjects.SetActive(false);
        InputController.Instance.isTouched = false;  //stop character when back to menu
    }
}
