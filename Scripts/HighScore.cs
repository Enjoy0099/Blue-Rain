using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Text playerName;

    [SerializeField]
    private Text highScore;

    private int currentScore;
    private string currentNameSet;
    
    public void Intro()
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {

        currentNameSet = PlayerPrefs.GetString(TagManager.PLAYER_NAME);
        playerName.text = PlayerPrefs.GetString(TagManager.HIGHSCORE_NAME);
        highScore.text = (PlayerPrefs.GetInt(TagManager.HIGH_SCORE).ToString());
        currentScore = PlayerMove.playerMoveIn.SendCurrentScore();

    }
    private void Start()
    {

        if (currentScore > PlayerPrefs.GetInt(TagManager.HIGH_SCORE))
        {
            DataManage.SetHighScore(currentScore);
            PlayerPrefs.SetString(TagManager.HIGHSCORE_NAME, currentNameSet);
            playerName.text = PlayerPrefs.GetString(TagManager.HIGHSCORE_NAME);
            highScore.text = (PlayerPrefs.GetInt(TagManager.HIGH_SCORE).ToString());
        }

    }
    
}
