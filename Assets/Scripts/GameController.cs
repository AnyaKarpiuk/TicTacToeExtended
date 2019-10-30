using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public Text[] buttonList;
    private string playerSide;

    public Text[] edgeButtons;

    int[,] rows = new int[24,3] { {0, 1, 2}, {3, 4, 5}, {6, 7, 8},{0, 3, 6}, {1, 4, 7}, 
                                {2, 5, 8}, {0, 4, 8}, {2, 4, 6}, {9, 0, 1}, {10, 3, 4},
                                {11, 6, 7}, {12, 6, 4}, {13, 6, 3}, {14, 7, 4}, {15, 8, 5},
                                {16, 8, 4}, {17, 8, 7}, {18, 5, 4}, {19, 2, 1}, {20, 2, 4},
                                {21, 2, 5}, {22, 1, 4}, {23, 0, 3}, {24, 0, 4}};

    //disable extra buttons and edge buttons by default
    void Start ()
    {

        for (int i = 9; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }

        for (int i = 0; i < edgeButtons.Length; i++)
        {
            edgeButtons[i].GetComponentInParent<Button>().interactable = false;
        }
     }

    void Awake ()
    {
    	SetGameControllerReferenceOnButton();
        //let a player to fill a grid space from the first click
    	playerSide = "X";
        //let a player to enable Extra button from the first click on Edge Button
        addExtraButton();
    }

    void SetGameControllerReferenceOnButton()
    {
    	for (int i = 0; i < buttonList.Length; i++)
    	{
    		buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
    	}
        for (int i = 0; i < edgeButtons.Length; i++)
        {
            edgeButtons[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }

    }

    public string GetPlayerSide ()
    {
    	return playerSide;
    }

    //change the player's side
    void ChangeSides () 
    {

        if (playerSide == "X")
        { 
            playerSide = "O"; 
          
        } else 
        { 
            playerSide = "X";
        } 

         for (int i = 0; i < edgeButtons.Length; i++)
            {
                edgeButtons[i].GetComponentInParent<Button>().onClick.AddListener(() => {
                    if (playerSide == "O")
                    { 
                        playerSide = "X"; 
          
                    } else 
                    { 
                        playerSide = "O";
                    } 
                });
            }

    }

    //end the game if one player fill 3 grid space in a row
    public void EndTurn () 
    {
        for (int i = 0; i < rows.GetLength(0); i++)
        {
            if (buttonList[rows[i, 0]].text == playerSide &&
                buttonList[rows[i, 1]].text == playerSide &&
                buttonList[rows[i, 2]].text == playerSide)
            {
                GameOver();
            }
        }

    	ChangeSides();
    }

    public void addExtraButton()
    {
         edgeButtons[0].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[9].GetComponentInParent<Button>().interactable = true; 
            });
         edgeButtons[1].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[10].GetComponentInParent<Button>().interactable = true; 
            });
         edgeButtons[2].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[11].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[3].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[12].GetComponentInParent<Button>().interactable = true; 
            });
         edgeButtons[4].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[13].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[5].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[14].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[6].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[15].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[7].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[16].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[8].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[17].GetComponentInParent<Button>().interactable = true;   
            });
    }
 
     //enable an edge button if one of the players fill 2 space grids in a row
    public void enableEdgeButton()
    {

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide)
        {
            edgeButtons[0].GetComponentInParent<Button>().interactable = true;
        }
         if (buttonList[3].text == playerSide && buttonList[4].text == playerSide)
        {
            edgeButtons[1].GetComponentInParent<Button>().interactable = true;
        }
         if (buttonList[6].text == playerSide && buttonList[7].text == playerSide)
        {
            edgeButtons[2].GetComponentInParent<Button>().interactable = true;
        }
         if (buttonList[6].text == playerSide && buttonList[4].text == playerSide)
        {
            edgeButtons[3].GetComponentInParent<Button>().interactable = true;
        }
         if (buttonList[6].text == playerSide && buttonList[3].text == playerSide)
        {
            edgeButtons[4].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[7].text == playerSide && buttonList[4].text == playerSide)
        {
            edgeButtons[5].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[8].text == playerSide && buttonList[5].text == playerSide)
        {
            edgeButtons[6].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[8].text == playerSide && buttonList[4].text == playerSide)
        {
            edgeButtons[7].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[8].text == playerSide && buttonList[7].text == playerSide)
        {
            edgeButtons[8].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[5].text == playerSide && buttonList[4].text == playerSide)
        {
            edgeButtons[9].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[2].text == playerSide && buttonList[1].text == playerSide)
        {
            edgeButtons[10].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide)
        {
            edgeButtons[11].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide)
        {
            edgeButtons[12].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide)
        {
            edgeButtons[13].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide)
        {
            edgeButtons[14].GetComponentInParent<Button>().interactable = true;
        }
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide)
        {
            edgeButtons[15].GetComponentInParent<Button>().interactable = true;
        }

    }

    //disable all buttons(space buttons and edge buttons) when one of the player wins
    void GameOver () 
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;      
        }
        for (int i = 0; i < edgeButtons.Length; i++)
        {
            edgeButtons[i].GetComponentInParent<Button>().interactable = false;     
        }
    }
}
