using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("Main Level");
    }
   public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
