using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] string countPrefixText;
    [SerializeField] Text countDownText;
    [SerializeField] int secondsLeft = 100;
    [SerializeField] bool countDownOnStartGame = false;
    [SerializeField] bool pause = false;

    [Header("On Count Starts Events")]
    [SerializeField] UnityEvent<GameObject> OnStartEvents;

    [Header("On Count Downing Events")]
    [SerializeField] int everyXSeconds = 1;
    [SerializeField] UnityEvent<GameObject> OnXSecondsTriggerEvents;

    [Header("On Count Down Ended Events")]
    [SerializeField] UnityEvent<GameObject> OnTimeRunsOutEvents;

    [SerializeField] bool startedCountDown = false;

    private void Start()
    {
        if (countDownOnStartGame)
        {
            StartCountDown();
        }
    }
    public void StartCountDown()
    {
        if (startedCountDown == false)
        {
            startedCountDown = true;
            OnStartEvents.Invoke(null);
            StartCoroutine(CountingDown());
        }
        else
        {
            Debug.LogError("You started the timer -" + this.gameObject.name + "- twice!");
        }
    }
    public void PauseToggle()
    {
        pause = !pause;
    }

    IEnumerator CountingDown()
    {
        while (secondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            if (!pause)
            {
                if (secondsLeft % everyXSeconds == 0)
                {
                    OnXSecondsTriggerEvents.Invoke(null);
                }
                secondsLeft--;
                if (countDownText)
                {
                    countDownText.text = countPrefixText + secondsLeft;
                }
            }
        }
        OnTimeRunsOutEvents.Invoke(null);
    }
}
