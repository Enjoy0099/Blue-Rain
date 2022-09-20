using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManage
{
    public static void SetHighScore(int HS)
    {
        PlayerPrefs.SetInt(TagManager.HIGH_SCORE, HS);
    }
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(TagManager.HIGH_SCORE);
    }
}
