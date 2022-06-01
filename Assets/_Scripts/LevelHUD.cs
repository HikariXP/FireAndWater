using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Include HP Display
public class LevelHUD : MonoBehaviour
{
    public List<GameObject> RedHPs = new List<GameObject>();
    public List<GameObject> BlueHPs = new List<GameObject>();

    public void Update()
    {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        for (int i = 0; i < 3; i++)
        {
            if (LevelManager.Instance.RedPlayerLives > i)
            {
                RedHPs[i].SetActive(true);
            }
            else
            {
                RedHPs[i].SetActive(false);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (LevelManager.Instance.BluePlayerLives > i)
            {
                BlueHPs[i].SetActive(true);
            }
            else
            {
                BlueHPs[i].SetActive(false);
            }
        }
    }
}
