using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnRateInSeconds = 1.0f;
    private float lastSpawnTime = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        float currentTime = Time.time;
        if (Input.GetKeyDown(KeyCode.Space) && (currentTime >= lastSpawnTime + spawnRateInSeconds || lastSpawnTime == 0.0f))
        {
            lastSpawnTime = currentTime;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
