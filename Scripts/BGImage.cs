using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGImage : MonoBehaviour
{
    private int count;
    public void ChangeBG()
    {
        count++;
        count = count % 4;
        setBG();
    }

    void setBG()
    {
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        PlayerPrefs.SetInt(TagManager.BGCount, count);
        transform.GetChild(count).gameObject.SetActive(true);
    }

    private void Awake()
    {
        count = PlayerPrefs.GetInt(TagManager.BGCount);
        setBG();
    }
}
