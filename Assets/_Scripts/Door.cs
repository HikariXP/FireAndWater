using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //0:Red     1:Blue
    public int DoorType;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (DoorType == 0)
        {
            if (collision.CompareTag("RedPlayer"))
            {
                PlayerEnter(0);
            }
        }
        if (DoorType == 1)
        {
            if (collision.CompareTag("BluePlayer"))
            {
                PlayerEnter(1);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (DoorType == 0)
        {
            if (collision.CompareTag("RedPlayer"))
            {
                PlayExit(0);
            }
        }
        if (DoorType == 1)
        {
            if (collision.CompareTag("BluePlayer"))
            {
                PlayExit(1);
            }
        }
    }

    public void PlayerEnter(int PlayerNo)
    {
        if (PlayerNo == 0)
        {
            LevelManager.Instance.SetPlayerReach(0,true);    
        }
        if (PlayerNo == 1)
        {
            LevelManager.Instance.SetPlayerReach(1, true);
        }
    }

    public void PlayExit(int PlayerNo)
    {
        if (PlayerNo == 0)
        {
            LevelManager.Instance.SetPlayerReach(0, false);
        }
        if (PlayerNo == 1)
        {
            LevelManager.Instance.SetPlayerReach(1, false);
        }
    }
}
