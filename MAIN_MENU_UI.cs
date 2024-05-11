using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAIN_MENU_UI : MonoBehaviour
{
    public GameObject main_menu_ui_panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Start_button(int sceneID)
    {
      SceneManager.LoadScene(sceneID);
    }
}
