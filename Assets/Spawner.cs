using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public int spawnCount;
    [Range(1, 100)] public int spawnSize = 1;
    public float minionOffset = 1;
    public GameObject minion;

    void OnEnable()
    {
        EventManager.StartListening("Spawn", Spawn);
    }

    void OnDisable()
    {
        EventManager.StopListening("Spawn", Spawn);
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var spawnPosition = GetSpawnPosition();
            var spawnRotation = new Quaternion();
            spawnRotation.eulerAngles = new Vector3(0f, Random.Range(0f, 360f));
            if (spawnPosition != Vector3.zero)
            {
                Instantiate(minion, spawnPosition, spawnRotation);
            }
        }
    }

    private Vector3 GetSpawnPosition()
    {
        var spawnPosition = new Vector3();
        var startTime = Time.realtimeSinceStartup;
        var test = false;
        while (test == false)
        {
            var spawnPositionRaw = Random.insideUnitCircle*spawnSize;
            spawnPosition = new Vector3(spawnPositionRaw.x, minionOffset, spawnPositionRaw.y);
            test = !Physics.CheckSphere(spawnPosition, .75f);
            if (Time.realtimeSinceStartup - startTime > .5f)
            {
                Debug.Log("Time out placing Minion!");
                return Vector3.zero;
            }
        }
        return spawnPosition;
    }
}
