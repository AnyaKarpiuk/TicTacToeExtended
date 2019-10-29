using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    
    public Button button;
    public Text buttonText;

    private GameController gameController;

    public void SetSpace () 
    {
    	buttonText.text = gameController.GetPlayerSide();
        gameController.enableEdgeButton(); 
    	button.interactable = false;            //disables a space button once it's pressed  
    	gameController.EndTurn();
    }

    //if an edge button is pressed - enable an extra button
    public void addSpace()
    {
        gameController.addExtraButton();
        button.interactable = false;           //disables an edge button once it's pressed                       
    }

    public void SetGameControllerReference (GameController controller) 
    {
    	gameController = controller;
    }
}
