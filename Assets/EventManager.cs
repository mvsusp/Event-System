using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, UnityEvent> _eventDictionaty;
    private static EventManager _eventManager;

    public static EventManager Instance
    {
        get
        {
            if (!_eventManager)
            {
                _eventManager = FindObjectOfType<EventManager>();
                if (!_eventManager)
                {
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                }
                else
                {
                    _eventManager.Init();
                    return _eventManager;
                }
            }
            return _eventManager;
        }
    }

    private void Init()
    {
        if (_eventDictionaty == null)
        {
            _eventDictionaty = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Instance._eventDictionaty.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance._eventDictionaty.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (_eventManager == null)
        {
            return;
        }
        UnityEvent thisEvent;
        if (Instance._eventDictionaty.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent;
        if (Instance._eventDictionaty.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
