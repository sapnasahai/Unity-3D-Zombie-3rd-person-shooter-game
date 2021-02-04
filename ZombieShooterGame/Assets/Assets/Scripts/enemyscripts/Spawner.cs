using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     
    float _nextSpawnTime;

    [SerializeField] float  _spawnDelay = 12f;
    [SerializeField] enemymovement  _EnemyPrefab;


    // Update is called once per frame
    void Update()
    {
        if (ReadyToSpawn()) 
            StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        _nextSpawnTime = Time.time + _spawnDelay;
        var enemy = Instantiate(_EnemyPrefab, transform.position, transform.rotation);
        
        GetComponent<Animator>().SetBool("Open", true);
        yield return new WaitForSeconds(1f);
        enemy.StartWalking();

        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().SetBool("Open", false);
    }


    bool ReadyToSpawn() => Time.time >= _nextSpawnTime;
}
