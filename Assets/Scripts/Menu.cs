using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public void Start()
	{
		FindObjectOfType<AudioManager>().Play("MenuMusic");
	}

    public void StartGame () 
    {
    	SceneManager.LoadScene(1);
    }

    public void startThreePlayersGame()
    {
    	SceneManager.LoadScene(2);
    }

    public void startTutorial()
    {
        SceneManager.LoadScene(3);
    }

    public void returnToMenu () 
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame () {
        Application.Quit();
    }

}
