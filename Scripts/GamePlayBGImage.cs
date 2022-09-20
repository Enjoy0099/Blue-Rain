using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayBGImage : MonoBehaviour
{
    private int setBG_Image;

    private void Awake()
    {
        setBG_Image = PlayerPrefs.GetInt(TagManager.BGCount);

        for(int i = 0; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        transform.GetChild(setBG_Image).gameObject.SetActive(true);
    }
}
