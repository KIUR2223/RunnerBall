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

    
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        numberOfCoins = 0;
        nextLevel = false;
    }

    void Update()
    {
        //hojigdoh vyiin panel
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        //zoosnii text dairsn zoos +dej hragdn
        CoinsText.text = "Coins: " + numberOfCoins;

        //daraagiin vylv ocih panel
        if (nextLevel)
        {
            Time.timeScale = 0;
            NextLevelPanel.SetActive(true);
        }
    }
}
