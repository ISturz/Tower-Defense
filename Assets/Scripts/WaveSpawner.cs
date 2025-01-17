using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITNG, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    


    void Start() 
    {
        waveCountdown = timeBetweenWaves;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == SpawnState.WAITNG)
        {
            if (!EnemyIsAlive())
            {
                //Begin new wave
               // Debug.Log("Wave Completed");
                nextWave++;

            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start wave if countdown is 0
                StartCoroutine(SpawnWave(waves[nextWave]));
                
            }
        }
        else 
        {
            waveCountdown -= Time.deltaTime;
        }
        
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                
                return false;
                
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawning Wave: " + _wave.waveName);
        state = SpawnState.SPAWNING;

        //Spawn
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITNG;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spawning Enemy");

        Transform spawn1 = GameObject.FindGameObjectWithTag("Spawn1").transform;
        Transform spawn2 = GameObject.FindGameObjectWithTag("Spawn2").transform;

        int rand = UnityEngine.Random.Range(0, 2);
        if (rand == 1)
        {
            Instantiate(_enemy, spawn1.transform.position, spawn1.transform.rotation);
        }
        else{
            Instantiate(_enemy, spawn2.transform.position, spawn2.transform.rotation);
        }
    }

}
