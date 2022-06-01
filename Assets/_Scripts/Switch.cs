using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isOn = true;

    public Sprite SwitchOn;
    public Sprite SwitchOff;

    private SpriteRenderer spriteRenderer;

    public Transform Door;

    public Vector3 DoorOnVector;
    public Vector3 DoorOffVector;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        ChangeDoorPos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedPlayer") || collision.CompareTag("BluePlayer"))
        {
            OnChangeSwitch();
        }
    }

    private void OnChangeSwitch()
    { 
        isOn = isOn==true?false:true;
        if (isOn)
        {
            spriteRenderer.sprite = SwitchOn;
        }
        else
        { 
            spriteRenderer.sprite = SwitchOff;
        }
    }

    public void ResetSwitch()
    {
        spriteRenderer.sprite = SwitchOn;
        isOn = true;
        Door.position = DoorOnVector;
    }

    public void ChangeDoorPos()
    {
        if (isOn)
        {
            Door.position = Vector3.Lerp(Door.position, DoorOnVector, Time.deltaTime);
        }
        else
        {
            Door.position = Vector3.Lerp(Door.position, DoorOffVector, Time.deltaTime);
        }
    }
}
