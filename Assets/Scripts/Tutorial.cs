using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
   
   public Image [] tutorial;
   public Text [] text;
   public Button [] button;

   public void Start()
   {
   		//hide all tutorial images
   		for (int i = 0; i < tutorial.Length; i ++)
   		{
   			tutorial[i].rectTransform.sizeDelta = new Vector2(0, 0);
    	}
    	//change a font size of text to 1 so it wouldn't be visible
    	for (int i = 0; i < text.Length; i ++)
   		{
   			text[i].fontSize = 1;
    	}
    	// make all next buttons invisible
    	for (int i = 1; i < button.Length; i ++)
   		{
   			button[i].gameObject.SetActive(false);
    	}

   }

   // return to main menu if a player wants to stop tutorial
   public void returnToMenu () 
    {
    	SceneManager.LoadScene(0);
    }

    // change images when buttons pressed
   public void buttonClicked ()
    {

    		text[0].fontSize = 30;

            tutorial[0].rectTransform.sizeDelta = new Vector2(500, 500);
    		tutorial[1].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[2].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[3].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[4].rectTransform.sizeDelta = new Vector2(0, 0);

    		button[0].gameObject.SetActive(false);
    		button[1].gameObject.SetActive(true);

    }

    public void buttonClicked1()
    {
    		text[0].fontSize = 1;
    		text[1].fontSize = 30;

            tutorial[0].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[1].rectTransform.sizeDelta = new Vector2(500, 500);
    		tutorial[2].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[3].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[4].rectTransform.sizeDelta = new Vector2(0, 0);

    		button[0].gameObject.SetActive(false);
    		button[1].gameObject.SetActive(false);
    		button[2].gameObject.SetActive(true);
    }

    public void buttonClicked2()
    {
    		text[0].fontSize = 1;
    		text[1].fontSize = 1;
    		text[2].fontSize = 30;

            tutorial[0].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[1].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[2].rectTransform.sizeDelta = new Vector2(500, 500);
    		tutorial[3].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[4].rectTransform.sizeDelta = new Vector2(0, 0);

    	for (int i = 1; i < 3; i ++)
   		{
   			button[i].gameObject.SetActive(false);
    	}

    		button[3].gameObject.SetActive(true);

    }

     public void buttonClicked3()
    {
    		text[0].fontSize = 1;
    		text[1].fontSize = 1;
    		text[2].fontSize = 1;
    		text[3].fontSize = 30;

            tutorial[0].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[1].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[2].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[3].rectTransform.sizeDelta = new Vector2(500, 500);
    		tutorial[4].rectTransform.sizeDelta = new Vector2(0, 0);

    	for (int i = 1; i < 4; i ++)
   		{
   			button[i].gameObject.SetActive(false);
    	}

    		button[4].gameObject.SetActive(true);

    }
    
    public void buttonClicked4()
    {
    	for (int i = 0; i < 4; i ++)
   		{
   			text[i].fontSize = 1;
    	}
    		text[4].fontSize = 30;

            tutorial[0].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[1].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[2].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[3].rectTransform.sizeDelta = new Vector2(0, 0);
    		tutorial[4].rectTransform.sizeDelta = new Vector2(500, 500);

    	for (int i = 1; i < 5; i ++)
   		{
   			button[i].gameObject.SetActive(false);
    	}

    		button[5].gameObject.SetActive(true);

    }

    
}

    	