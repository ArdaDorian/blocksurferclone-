using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] TMP_Text diamondCount_text, gameOverDiamond_text, winLose_text;

    private void Awake()
    {
        instance = this;
    }

    internal void IncreaseDiamond()
    {
        diamondCount_text.text = LevelManager.instance.diamondCount.ToString();
    }

    internal void GameOverDiamondText()
    {
        gameOverDiamond_text.text = diamondCount_text.text;
    }

    internal void WinOrLoseText(string status)
    {
        winLose_text.text = status;
    }
}
