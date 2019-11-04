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
        gameController.addExtraButton();
    	button.interactable = false;            //disables a space button once it's pressed  
    	gameController.EndTurn();
    }

    public void SetGameControllerReference (GameController controller) 
    {
    	gameController = controller;
    }

}
