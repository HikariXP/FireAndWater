using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//管理单一关卡的管理员
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public event Action GameOverEvent;

    public Vector3 RedPlayerStartPos;
    public Vector3 BluePlayerStartPos;

    public GameObject RedPlayer;
    public GameObject BluePlayer;

    public int RedPlayerLives;
    public int BluePlayerLives;

    public bool RedReachDoor;
    public bool BlueReachDoor;

    public bool isWin;

    public int LevelNo;

    public List<Switch> switches = new List<Switch>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ReStartLevel();
    }

    //When Player Dead
    public void ResetPlayer(int PlayerNo)
    {
        //Red = 0; Blue = 1;
        if (PlayerNo == 0)
        {
            RedPlayerLives -= 1;
            RedPlayer.transform.position = RedPlayerStartPos;
        }
        else
        { 
            BluePlayerLives -= 1;
            BluePlayer.transform.position= BluePlayerStartPos;
        }
        if (BluePlayerLives < 0 || RedPlayerLives < 0)
        { 
            OnGameOver();
        }
    }

    public void ReStartLevel()
    {
        RedPlayer.transform.position = RedPlayerStartPos;
        BluePlayer.transform.position = BluePlayerStartPos;

        RedPlayerLives = 3;
        BluePlayerLives = 3;

        if (switches.Count > 0)
        {
            foreach (Switch sh in switches)
            {
                sh.ResetSwitch();
            }
        }
    }

    public void SetPlayerReach(int PlayerNo,bool isReach)
    {
        if (PlayerNo == 0)
        { 
            RedReachDoor = isReach;
        }
        if (PlayerNo == 1)
        {
            BlueReachDoor = isReach;
        }

        if (BlueReachDoor & RedReachDoor)
        {
            OnGameOver();
        }
    }

    public void OnGameOver()
    {
        if (RedPlayerLives >= 0 && BluePlayerLives >= 0)
        {
            isWin = true;
            if (GameManager.Instance != null)
            {
                if (GameManager.Instance.LevelPass < LevelNo)
                {
                    GameManager.Instance.LevelPass = LevelNo;
                }
            }
        }
        else
        { 
            isWin = false;
        }
        GameOverEvent?.Invoke();
    }
}
