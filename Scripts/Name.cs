using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{

    [SerializeField]
    private Text Get_Name;

    public void StartGameIntro() 
    {
        
        if(Get_Name.text != string.Empty)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: 1);
            PlayerPrefs.SetString(TagManager.PLAYER_NAME, Get_Name.text);
        }
    }
}
