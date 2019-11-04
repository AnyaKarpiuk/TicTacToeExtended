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

}
