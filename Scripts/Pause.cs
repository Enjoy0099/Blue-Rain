using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Pause_G;
    public GameObject Resume_G;

    public void pauseGame()
    {
        Time.timeScale = 0;
        Pause_G.SetActive(false);
        Resume_G.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pause_G.SetActive(true);
        Resume_G.SetActive(false);
    }

    public void ExitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
