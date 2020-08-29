using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button levelSelectButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
//        levelSelectButton.AddListener(SelectLevel);    
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
        SceneManager.LoadScene("Test_Area");
    }
}
