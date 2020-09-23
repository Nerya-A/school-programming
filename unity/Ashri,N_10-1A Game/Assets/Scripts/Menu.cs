using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button tutorialButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        tutorialButton.onClick.AddListener(SelectLevel);    
    }

    void QuitGame() 
    {
        Application.Quit();
    }

    void StartGame() 
    {
        SceneManager.LoadScene("Level_1");
    }
    
    void SelectLevel()
    {
        SceneManager.LoadScene("Tutorial_Level");
    }
}
