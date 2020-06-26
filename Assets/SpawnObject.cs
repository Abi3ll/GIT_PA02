using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Transform[] spawnpoint;
    public GameObject[] prefabs;
    public float minTime, maxTime;
    public int numberofspawns = 2;
    private float timer = 0f;
    private int lastspawnpointindex = -1;
    // Start is called before the first frame update
    void Start()
    {
       
    }
   
    // Update is called once per frame
    void Update()
    {
     
        if(timer <= 0f)
        {
            SpawnItems();
            resetTimer();
        }
        timer -= Time.deltaTime;
        
    }
    private void SpawnItems()
    {
        for (int i = 0;  i < numberofspawns; i++)
        {
            Transform spawnpoint = GetNextSpawnPoint();
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            Instantiate(prefab, spawnpoint);
        }
    }
    private Transform GetNextSpawnPoint()
    {
        int index = (lastspawnpointindex + Random.Range(1, spawnpoint.Length - 1)) % spawnpoint.Length;
        lastspawnpointindex = index;
        return spawnpoint[index];
    }
    private void resetTimer()
    {
        timer = Random.Range(minTime, maxTime);
    }
}
