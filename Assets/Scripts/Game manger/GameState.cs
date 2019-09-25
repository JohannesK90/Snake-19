using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    #region Variables
    public bool resetTrue;

    bool startState;
    bool continueState;
    bool pauseState;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    #endregion

    private void Awake()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
    }

    public enum GameStateEnum
    {
        Pause,
        GameOver
    }

    public GameStateEnum stateEnum;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseState)
            {
                Debug.Log("Escape key true.");
                PauseGame();
            }
            else
            {
                Debug.Log("play");
                ContinueGame();
                pauseState = false;
            }

        }
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseState = true;
        stateEnum = GameStateEnum.Pause;
        Debug.Log("Pause state active.");
        Time.timeScale = 0f;

    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        stateEnum = GameStateEnum.GameOver;
        Time.timeScale = 0;
    }

    public void ResetGame()
    {

        if (resetTrue)
        {
            Debug.Log("reset is true!");
            SceneManager.LoadScene(0);
            resetTrue = false;
        }
    }

    public void QuitGameYes()
    {
        Debug.Log("Player quit the game.");
        Application.Quit();
    }

    public void QuitGameNo()
    {
        if (stateEnum == GameStateEnum.GameOver)
        {
            gameOverMenu.SetActive(true);
        }
        if (stateEnum == GameStateEnum.Pause)
        {
            pauseMenu.SetActive(true);
        }
    }
}
