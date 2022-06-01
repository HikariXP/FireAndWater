using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private DIYSceneManager sceneManager;

    public int LevelPass = 0;

    private void Awake()
    {
        sceneManager = GetComponent<DIYSceneManager>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }

    public void OnLoadLevel(string LevelName)
    {
        sceneManager.LoadScene(LevelName,"",0f);
    }
}
