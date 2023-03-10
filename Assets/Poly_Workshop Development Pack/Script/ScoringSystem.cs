using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ScoringSystem : MonoBehaviour
{
    [SerializeField] string scorePrefixText;
    [SerializeField] Text scoreText;
    [SerializeField] int currentScore = 0;

    public List<ScoringTriggerSetting> scoringSettingList;
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (scoreText)
        {
            scoreText.text = scorePrefixText + currentScore;
        }

        List<ScoringTriggerSetting> eventsToTrigger = scoringSettingList.FindAll(s => s.scoreThreshold <= currentScore);
        for (int i = 0; i < eventsToTrigger.Count; i++)
        {
            if (eventsToTrigger[i].onlyTriggerWhenEquals && currentScore != eventsToTrigger[i].scoreThreshold)
                continue;
            eventsToTrigger[i].OnReachScoreEvents.Invoke(null);
        }
    }
}
[System.Serializable]
public class ScoringTriggerSetting
{
    public bool onlyTriggerWhenEquals = false;
    public int scoreThreshold;
    public UnityEvent<GameObject> OnReachScoreEvents;

}
