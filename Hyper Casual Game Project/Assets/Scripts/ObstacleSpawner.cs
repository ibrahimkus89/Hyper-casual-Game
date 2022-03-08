using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    Vector3 spawnPos;
    public float spawnRate;
    void Start()
    {
        spawnPos = transform.position;

        //Spawn();

        StartCoroutine(SpawnObstacles());
    }

    
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();

            GameManager.instance.UpdateScore();

            yield return new WaitForSeconds(spawnRate);
        }
    }
    void Spawn()
    {
        int randObstacle = Random.Range(0,obstacles.Length);

        int randomSpot = Random.Range(0,2); // 0=top, 1=bottom

        spawnPos = transform.position;

        if (randomSpot <1)
        {
            Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);

        }
        else
        {
            
            //spawnPos = new Vector3(transform.position.x,-transform.position.y,transform.position.z);
            spawnPos.y = -transform.position.y;

            if (randObstacle ==1)
            {
                spawnPos.x += 1;
            }
            else if (randObstacle ==2)
            {
                spawnPos.x += 2;

            }

            GameObject obs = Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 0, 180);

        }

        
    }
}
