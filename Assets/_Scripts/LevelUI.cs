using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public GameObject GameOverPanel;

    public Text TitleText;

    private void Start()
    {
        LevelManager.Instance.GameOverEvent += OnGameOver;
    }

    public void RefreshTitle()
    {
        if (LevelManager.Instance.isWin)
        {
            TitleText.text = "Win";
        }
        else
        {
            TitleText.text = "Lose";
        }
    }

    public void OnGameOver()
    {
        GameOverPanel.SetActive(true);
        RefreshTitle();
    }

    public void OnBackToTitle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnLoadLevel("Title");
        }
    }
}
