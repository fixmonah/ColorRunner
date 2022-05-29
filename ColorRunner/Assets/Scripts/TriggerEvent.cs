using System;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private Action onTrigger; // not best of security. Best use is Event

    public void SetAction(Action action)
    {
        onTrigger = action;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            onTrigger?.Invoke();
        }
    }
}
