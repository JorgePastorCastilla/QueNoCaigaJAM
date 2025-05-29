using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject winCanvas;
    public GameObject gameOverCanvas;
    
    public void Win()
    {
        Time.timeScale = 0;
        winCanvas.SetActive(true);
    }
    
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
        winCanvas.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void GotoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
