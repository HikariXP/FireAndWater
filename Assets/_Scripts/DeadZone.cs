using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [Tooltip("-1:Both   0:Red   1:Blue")]
    public int DeadZoneType;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (DeadZoneType == -1)
        {
            if (collision.CompareTag("RedPlayer"))
            {
                RedPlayerDead();
            }
            if (collision.CompareTag("BluePlayer"))
            {
                BluePlayerDead();
            }
        }
        if (DeadZoneType == 0)
        {
            if (collision.CompareTag("RedPlayer"))
            {
                RedPlayerDead();
            }
        }
        if (DeadZoneType == 1)
        {
            if (collision.CompareTag("BluePlayer"))
            {
                BluePlayerDead();
            }
        }
    }

    public void RedPlayerDead()
    {
        LevelManager.Instance.ResetPlayer(0);
    }

    public void BluePlayerDead()
    {
        LevelManager.Instance.ResetPlayer(1);
    }
}
