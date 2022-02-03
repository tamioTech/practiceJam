using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] Transform spawnPointTr;

    Vector3 randomSpawnPoint;

    private void Start()
    {
        randomSpawnPoint = spawnPointTr.position;
    }

    private void Update()
    {

    }

    public void SpawnEnemy()
    {
        print(randomSpawnPoint);
        GameObject newEnemy = Instantiate(spawnPrefab, RandomSpawnVector3(), Quaternion.identity);
    }

    private Vector3 RandomSpawnVector3()
    {
        float minX = spawnPointTr.position.x - 10f;
        print(minX);
        float rndX = Random.Range(spawnPointTr.position.x - 10f, spawnPointTr.position.x + 10f);
        float rndY = Random.Range(spawnPointTr.position.y - 10f, spawnPointTr.position.y + 10f);

        Vector3 rsp = new Vector3(rndX, rndY, 0);

        print(rsp);
        return rsp;
    }
}
