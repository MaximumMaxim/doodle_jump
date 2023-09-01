using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject frogePrefab;
    public GameObject beePrefab;
    public GameObject birdPrefab;
    public Transform spawnPointForFrog;
    public Transform spawnPointForBee;
    public Transform spawnPointForBird;
    public Transform PlayerPosition;

    public float IntervalForFrog;
    public float IntervalForBee;
    public float IntervalForBird;

    private void Start()
    {
        StartCoroutine(SpawnEnemyFixed());
        StartCoroutine(SpawnEnemyRandom());
        StartCoroutine(SpawnEnemyFixedTwo());
    }
   
    private IEnumerator SpawnEnemyFixed()
    {
        while(true)
        {
            yield return new WaitForSeconds(IntervalForFrog);
            Vector3 spawnPosition = spawnPointForFrog.position + new Vector3(0f, PlayerPosition.position.y +10f, 0f);
            Instantiate(frogePrefab, spawnPosition, Quaternion.identity);
        }
    }

    private IEnumerator SpawnEnemyFixedTwo()
    {
        while (true)
        {
            yield return new WaitForSeconds(IntervalForBird);
            Vector3 spawnPosition = spawnPointForBird.position + new Vector3(0f, PlayerPosition.position.y + 10f, 0f);
            Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private IEnumerator SpawnEnemyRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(IntervalForBee);
            Vector3 spawnPosition = spawnPointForBee.position + new Vector3(Random.Range(-2f,2f),PlayerPosition.position.y +10f,0f);
            Instantiate(beePrefab, spawnPosition, Quaternion.identity);
        }
    }
}

