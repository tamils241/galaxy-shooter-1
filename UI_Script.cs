using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    
    public Button Reset;//Reset Button //
    public TMP_Text score_text; // score text 
    private int score; // score increament value
    public GameObject PausePanel;
    public GameObject sliderPanel;

     void Start()
    {
      
      score = 0;
    
    }

     public void score_display()
    {
         score++;
         score_text.text = "Score:"+score;
         Debug.Log("score");
    }
   
    public void Setting_button()
    {
      sliderPanel.SetActive(true);
    }

    // game reset fucunction;
    public void Reset_button()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // game pause function //
    public void Pause_button()
    {
     PausePanel.SetActive(true);
     Time.timeScale = 0;
    }

    //game resume function //
    public void Resume_button()
    {
       PausePanel.SetActive(false);
       sliderPanel.SetActive(false);
       Time.timeScale = 1;
    }

    // game Exit function // 
    public void Exit_button()
    {
      Application.Quit();
    }

}

