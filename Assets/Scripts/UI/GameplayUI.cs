using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private TextMeshProUGUI scoreText;
    private GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        gManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gManager.GetScore();
        healthBar.sizeDelta = new Vector2(300 * gManager.GetLivePercentage(), 100);
    }
}
