using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    //daraagiin vylv shiljih
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //ahintogloh 
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }
    //togloomoos garah
    public void QuitGame()
    {
        Application.Quit();
    }
}
