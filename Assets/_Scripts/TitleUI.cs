using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    public List<GameObject> LevelButtons = new List<GameObject>();

    public void OnRefreshLevelButtons()
    {
        for (int i = 0; i < LevelButtons.Count-1; i++)
        {
            if (i < GameManager.Instance.LevelPass)
            {
                LevelButtons[i+1].GetComponent<Button>().interactable = true;
            }
            else
            {
                LevelButtons[i+1].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void OnSelectLevel(string levelName)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnLoadLevel(levelName);
        }
    }
}
