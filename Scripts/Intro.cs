using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    private string bgNumber;

    [SerializeField]
    private Text player_Name;

    public void ExitGame()
    {
        PlayerPrefs.SetInt(TagManager.BGCount, 0);
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Score_Info()
    {
        SceneManager.LoadScene(3);
    }

    public void Change_Name()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        player_Name.text = PlayerPrefs.GetString(TagManager.PLAYER_NAME);
    }

}
