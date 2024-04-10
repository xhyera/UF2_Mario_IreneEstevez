using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoint;
    public float waitTime = 3f;
    public float timer;
    private bool activateSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(activateSpawn)
        {
            SpawnEnemy();
        }
        
        
    }
    void SpawnEnemy()
    {
        timer += Time.deltaTime;
        if(timer >= waitTime)
        {
            //esto es para cuando la variable era normal
            //Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            //esto es para el array
            // Instantiate(enemyPrefab[], spawnPoint[0].position, spawnPoint[0].rotation);
            // Instantiate(enemyPrefab[], spawnPoint[1].position, spawnPoint[1].rotation);
            // Instantiate(enemyPrefab[], spawnPoint[2].position, spawnPoint[2].rotation);


            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint[Random.Range(0, enemyPrefab.Length)].position, spawnPoint[Random.Range(0, enemyPrefab.Length)].rotation);
            timer = 0;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            activateSpawn = true;
        }
    }
       void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            activateSpawn = false;
        }
    }
}
