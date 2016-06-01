using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Test1 : MonoBehaviour
{
    private UnityAction _someListener;

    void Awake()
    {
        _someListener = SomeFunction;
    }

    void OnEnable()
    {
        EventManager.StartListening("test", _someListener);           
    }

    void SomeFunction()
    {
        Debug.Log("Some function was called.");
    }

    void OnDisable()
    {
        EventManager.StopListening("test", _someListener);
    }


}
