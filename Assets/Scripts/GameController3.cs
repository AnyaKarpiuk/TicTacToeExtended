using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController3 : MonoBehaviour
{
    
    public Text[] buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text winningText;
    public Button startAgain;
    public Button menuButton;

    public Text[] edgeButtons;
    public Image[] turns;

    int[,] rows = new int[48,3] { {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, {0, 4, 8}, 
                                {2, 4, 6}, {9, 0, 1}, {10, 3, 4}, {11, 6, 7}, {12, 6, 4}, {13, 6, 3}, {14, 7, 4}, 
                                {15, 8, 5}, {16, 8, 4}, {17, 8, 7}, {18, 5, 4}, {19, 2, 1}, {20, 2, 4}, {21, 2, 5}, 
                                {22, 1, 4}, {23, 0, 3}, {24, 0, 4}, {24, 9, 10}, {9, 10, 11}, {10, 11, 12}, 
                                {12, 13, 14}, {13, 14, 15}, {14, 15, 16}, {16, 17, 18}, {17, 18, 19}, {18, 19, 20},
                                {20, 21, 22}, {21, 22, 23}, {22, 23, 24}, {10, 6, 14}, {18, 8, 14}, {22, 2, 18}, 
                                {22, 0, 10}, {9, 3, 7}, {3, 7, 15}, {19, 5, 7}, {5, 7, 13}, {23, 1, 5}, {1, 5, 17}, 
                                {21, 1, 3}, {1, 3, 11}};

    //disable extra buttons and edge buttons by default
    public void Start ()
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

    public void Awake ()
    {

    	SetGameControllerReferenceOnButton();
        //let a player to fill a grid space from the first click
    	playerSide = "X";
        //make X's icon large by default
        turns[0].rectTransform.sizeDelta = new Vector2(180, 180);

        gameOverPanel.SetActive(false);

    }

    public void SetGameControllerReferenceOnButton()
    {

    	for (int i = 0; i < buttonList.Length; i++)
    	{
    		buttonList[i].GetComponentInParent<GridSpace3>().SetGameControllerReference(this);
    	}
       
    }

    public string GetPlayerSide ()
    {
    	return playerSide;
    }

    //change the player's side
    public  void ChangeSides () 
    {

        if (playerSide == "X")
        { 
            playerSide = "O"; 
        } else if (playerSide == "O")
        { 
            playerSide = "V";
        } else 
        {
        	playerSide = "X";
        }

        //if a player presses an Edge Button he skips a turn
        for (int i = 0; i < edgeButtons.Length; i++)
        {
            if ( playerSide == "X")
            {
                edgeButtons[i].GetComponentInParent<Button>().onClick.AddListener(() => {
                    playerSide = "O";

                    changeTurnIconsAndMusic();
                });
            } else if (playerSide == "O")
            {
                edgeButtons[i].GetComponentInParent<Button>().onClick.AddListener(() => {
                    playerSide = "V";

                    changeTurnIconsAndMusic();
                });
            } else 
            {
                edgeButtons[i].GetComponentInParent<Button>().onClick.AddListener(() => {
                    playerSide = "X";

                    changeTurnIconsAndMusic();
                });
        }
    }

        changeTurnIconsAndMusic();
    }

    //chang the size of icons 
    public void changeTurnIconsAndMusic()
    {
        if (playerSide == "X")
        {
            //play sound when player X presses a button
            FindObjectOfType<AudioManager>().Play("playerX");
            
            turns[0].rectTransform.sizeDelta = new Vector2(80, 80);
            turns[1].rectTransform.sizeDelta = new Vector2(80, 80);
            turns[2].rectTransform.sizeDelta = new Vector2(180, 180);
        } else if (playerSide == "O")
        {
            //play sound when player O presses a button
            FindObjectOfType<AudioManager>().Play("playerO");

            turns[0].rectTransform.sizeDelta = new Vector2(180, 180);
            turns[1].rectTransform.sizeDelta = new Vector2(80, 80);
            turns[2].rectTransform.sizeDelta = new Vector2(80, 80);
        } else {
        	FindObjectOfType<AudioManager>().Play("playerO");

            turns[0].rectTransform.sizeDelta = new Vector2(80, 80);
            turns[1].rectTransform.sizeDelta = new Vector2(180, 180);
            turns[2].rectTransform.sizeDelta = new Vector2(80, 80);
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

    //if a player presses one of edge buttons - create an extra button
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
         edgeButtons[9].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[18].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[10].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[19].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[11].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[20].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[12].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[21].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[13].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[22].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[14].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[23].GetComponentInParent<Button>().interactable = true;   
            });
         edgeButtons[15].GetComponentInParent<Button>().onClick.AddListener(() => {
                buttonList[24].GetComponentInParent<Button>().interactable = true;   
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
        menuButton.interactable = false;

        //display a winner
        gameOverPanel.SetActive(true);
        winningText.text = playerSide + "  WINS !";

        //load a main menu scene when MenuButton is pressed
        startAgain.onClick.AddListener(() => {
                SceneManager.LoadScene(0);
            });

    }

}

