using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerate : MonoBehaviour
{
    public Transform platformPrefab, movePlatformPrefab, brokePlatformPrefab, destroyPlatformPrefab, bustPrefab;

    public float cameraDistance;
    public float levelWidth = 3;
    public float minY, maxY;
    public float minYforBroke, maxYforBroke;
    public float minYForDeastoy, maxYforDeastoy;
    public float minYforBust, maxYforBust;
    public float precentSpawnOfMMpf;

   
    private float lastSpawnY, rangeIncresore, rangeProcent;
    private float lastSpawnForBrokeY, lastSpawnForBustY, lastSpawnForDestroyY;
    private Transform cam;
    void Start()
    {
        cam = Camera.main.transform;
        lastSpawnY = 0; 
        lastSpawnForBrokeY = 0;
        lastSpawnForBustY = 0;
        lastSpawnForDestroyY = 0;
    }

    private void Update()
    {        
        if(lastSpawnY < 250)
        {
            rangeIncresore = Mathf.Floor(lastSpawnY / 50);           
        }

        if(lastSpawnY < 250&& rangeIncresore>0)
        {
            rangeProcent = Mathf.Floor(lastSpawnY / 50);
            rangeProcent = 1 - rangeProcent/ 10;
            precentSpawnOfMMpf = rangeProcent;
        }

        if(cam.position.y +cameraDistance > lastSpawnY)
        {
            Transform platform;
            if(Random.value <precentSpawnOfMMpf)
                platform = Instantiate(platformPrefab);
            else
                platform = Instantiate(movePlatformPrefab);
            platform.position = new Vector3(Random.Range(-levelWidth, levelWidth), lastSpawnY + Random.Range(minY +(rangeIncresore*0.55f), maxY + (rangeIncresore*0.55f)), 0);
            lastSpawnY = platform.position.y;
        }
        if(cam.position.y + cameraDistance > lastSpawnForBrokeY)
        {
            Transform brokePlatform;
            brokePlatform = Instantiate(brokePlatformPrefab);
            brokePlatform.position = new Vector3(Random.Range(-levelWidth, levelWidth), lastSpawnForBrokeY+ Random.Range(minYforBroke, maxYforBroke), 0);
            lastSpawnForBrokeY = brokePlatform.position.y;
        }

        if(cam.position.y + cameraDistance > lastSpawnForDestroyY)
        {
            Transform destroyPlatform;
            destroyPlatform = Instantiate(destroyPlatformPrefab);
            destroyPlatform.position = new Vector3(Random.Range(-levelWidth, levelWidth), lastSpawnForDestroyY + Random.Range(minYForDeastoy, maxYforDeastoy), 0);
            lastSpawnForDestroyY = destroyPlatform.position.y;
        }

        if(cam.position.y + cameraDistance > lastSpawnForBustY)
        {
            Transform bust;
            bust = Instantiate(bustPrefab);
            bust.position = new Vector3(Random.Range(-levelWidth, levelWidth), lastSpawnForBustY + Random.Range(minYforBust, maxYforBust), 0);
            lastSpawnForBustY = bust.position.y;
        }
    }


}
