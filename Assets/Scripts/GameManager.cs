using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currScore;
    [SerializeField] private int maxLives;
    private int currLives;

    public bool GameActive { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currScore = 0;
        currLives = Mathf.Clamp(maxLives, 0, maxLives);
        GameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currLives == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        GameActive = false;
        FindObjectOfType<UIManager>().Gameover();
    }

    public void TakeDamage()
    {
        currLives--;
    }

    public void AddScore(int score)
    {
        currScore += score;
    }
    public int GetScore()
    {
        return currScore;
    }

    public float GetLivePercentage()
    {
        return (float)currLives / (float)maxLives;
    }
}
