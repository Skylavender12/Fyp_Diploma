using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour

    
{
    
    public Text playerDisplay;

    public void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.username;
        }
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
