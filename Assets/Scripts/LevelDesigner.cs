using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public GameObject Container;
    public GameObject Spawner;
    public GameObject[] LevelPrefabs;

    [SerializeField] private List<GameObject> SpawnedLevels = new List<GameObject>();
    public Transform player;
    private int SpawnCount = 0;
    float currentPos;



    private void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();

        }
    }

    public void Init()
    {
        Spawn();
        Spawn();
    }
   
    private void Spawn()
    {
        Vector3 newPos = new Vector3(Container.transform.position.x, Container.transform.position.y, SpawnCount * 500);
        GameObject randomLevel = LevelPrefabs[Random.Range(0, LevelPrefabs.Length)];


        GameObject newLevel = Instantiate(randomLevel, newPos, Spawner.transform.rotation, Container.transform);
        SpawnedLevels.Add(newLevel);

        if (SpawnedLevels.Count >= 3)
        {
            Destroy(SpawnedLevels[0]);
            SpawnedLevels[0] = SpawnedLevels[1];
            SpawnedLevels[1] = SpawnedLevels[2];
            SpawnedLevels[2] = newLevel;

        }
        SpawnCount++;
    }
    private bool ShouldSpawn()
    {
        currentPos = player.position.z;


        if (currentPos >= (SpawnCount-1) * 500)
        {
            
            return true;
        }
        return false;

    }
    public void ResetLevel()
    {
        SpawnCount = 0;

        for (int i = 0; i < SpawnedLevels.Count; i++)
        {
            if (SpawnedLevels[i] != null)
            {
                Destroy(SpawnedLevels[i]);
            }
        }
        SpawnedLevels = new List<GameObject>();
        
       Init();
    }

}
