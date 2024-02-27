using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform gameplayUI;
    [SerializeField] private RectTransform pauseUI;
    [SerializeField] private RectTransform gameOverUI;

    [SerializeField] private TextMeshProUGUI finalScore;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        gameplayUI.gameObject.SetActive(false);
        pauseUI.gameObject.SetActive(true);
    }

    private void Unpause()
    {
        Time.timeScale = 1;
        gameplayUI.gameObject.SetActive(true);
        pauseUI.gameObject.SetActive(false);
    }

    public void Gameover()
    {
        Time.timeScale = 0;
        finalScore.text = "Final Score: " + FindObjectOfType<GameManager>().GetScore();
        gameplayUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
