using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle_Health : MonoBehaviour
{

    [SerializeField] private int healthMax = 20;
    [SerializeField] private int health = 0;

    private void Start()
    {
        health = healthMax;
    }

    private void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag != "PlayerBullet") { return; }

        health--;
        if(health<=0)
        {
            Destroy(gameObject);
            FindObjectOfType<Spawner>().SpawnEnemy();
        }
    }
}
