using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // The repeat delay is 3 seconds, and we can delay further 
        // by n seconds, where n is [0,2] so the max repeat rate
        // is 5 seconds and the min repeat rate is 3 seconds.
        float delay = Random.Range(0.0f, 2.0f);
        Delay(delay);
        Debug.Log("Ball spawning delayed by " + delay + " seconds. Total time since last spawn: " + (delay + spawnInterval));

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Random index in [0, numBallPrefabs - 1]
        // (Using int overload with exclusive maximum range)
        uint ballIndex = (uint)Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);
    }

    IEnumerable Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}
