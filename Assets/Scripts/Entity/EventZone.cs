using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventZone : MonoBehaviour
{
    private bool isEvent = false;
    private float holdTime = 0f;
    private float needHoldTime = 1.0f;
    private bool activeTime = false;

    UIManager uiManager;
    public UIManager UIManager {  get { return uiManager; } }
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEvent = true;
            uiManager.PressFkey(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            isEvent = false;
            holdTime = 0f;
            activeTime = false;

            uiManager.PressFkey(false);
            uiManager.ShowMiniGameUI_OFF();
        }
    }
    private void Update()
    {
        if (isEvent && !activeTime)
        {
            if(Input.GetKey(KeyCode.F))
            {
                holdTime += Time.deltaTime;
                if(holdTime >= needHoldTime)
                {
                    ActiveEvent();
                    holdTime = 0f;
                    activeTime = true;
                }
            }
            else
            {
                holdTime = 0f;
            }
        }
    }
    private void ActiveEvent()
    {
        uiManager.ShowMiniGameUI_ON();
    }
}
