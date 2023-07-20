using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    
    public static bool nextLevel;
    public GameObject NextLevelPanel;
    
    public static int numberOfCoins;
    public Text CoinsText;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        numberOfCoins = 0;
        nextLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        CoinsText.text = "Coins: " + numberOfCoins;

        if (nextLevel)
        {
            Time.timeScale = 0;
            NextLevelPanel.SetActive(true);
        }
    }
}
