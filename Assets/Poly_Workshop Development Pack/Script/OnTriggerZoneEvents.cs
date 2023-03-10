using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerZoneEvents : MonoBehaviour
{
    [Tooltip("If this is empty, everything will trigger the events")]
    [SerializeField] List<string> matchTags;
    [SerializeField] UnityEvent<GameObject> onTriggerEnter;
    [SerializeField] UnityEvent<GameObject> onTriggerStay;
    [SerializeField] UnityEvent<GameObject> onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (matchTags.Count == 0)
        {
            print(other.name + " On Trigger Entered");
            onTriggerEnter.Invoke(null);
        }
        else
        {
            for (int i = 0; i < matchTags.Count; i++)
            {
                if (other.gameObject.CompareTag(matchTags[i]))
                {
                    print(other.name + " On Trigger Entered");
                    onTriggerEnter.Invoke(null);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (matchTags.Count == 0)
        {
            print(other.name + " On Trigger Staying");
            onTriggerStay.Invoke(null);
        }
        else
        {
            for (int i = 0; i < matchTags.Count; i++)
            {
                if (other.gameObject.CompareTag(matchTags[i]))
                {
                    print(other.name + " On Trigger Staying");
                    onTriggerStay.Invoke(null);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (matchTags.Count == 0)
        {
            print(other.name + " On Trigger Exited");
            onTriggerExit.Invoke(null);
        }
        else
        {
            for (int i = 0; i < matchTags.Count; i++)
            {
                if (other.gameObject.CompareTag(matchTags[i]))
                {
                    print(other.name + " On Trigger Exited");
                    onTriggerExit.Invoke(null);
                }
            }
        }
    }
}
