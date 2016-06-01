using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour {
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            EventManager.TriggerEvent("test");
        }

        if (Input.GetKeyDown("w"))
        {
            EventManager.TriggerEvent("Spawn");
        }

        if (Input.GetKeyDown("r"))
        {
            EventManager.TriggerEvent("Destroy");
        }
    }
}
