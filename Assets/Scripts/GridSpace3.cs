using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace3 : MonoBehaviour
{
    
    public Button button;
    public Text buttonText;

    private GameController3 gameController3;

    public void SetSpace () 
    {
    	buttonText.text = gameController3.GetPlayerSide();
        gameController3.enableEdgeButton();
        gameController3.addExtraButton();
    	button.interactable = false;            //disables a space button once it's pressed  
    	gameController3.EndTurn();
    }

    public void SetGameControllerReference (GameController3 controller) 
    {
    	gameController3 = controller;
    }

}
