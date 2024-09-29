using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class FruitInfo
{
    public float x;
    public Vector2 velocity = new Vector2(0, 10);
    public bool isBomb;
}

[Serializable]

public class Wave
{
    public List<FruitInfo> fruits;
    public bool isSequence;
    public bool isBomb;
}


public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject bomb;
    public List<Wave> waves;
    public float delay = 2f;
    public int currentWave;

    void Start()
    {
        print(waves[1].fruits[0].isBomb);
        Spawn();
    }

    async void Spawn()
    {
        for(currentWave = 0; currentWave < waves.Count;currentWave++)
        {
            for (int f = 0; f < waves[currentWave].fruits.Count; f++)
            {
                var fruit = waves[currentWave].fruits[f];

                GameObject obj = fruit.isBomb? bomb : prefabs[Random.Range(0, prefabs.Length)];
                Vector3 pos = transform.position + Vector3.right * fruit.x;
                Instantiate(obj, pos, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = fruit.velocity;

                if (waves[currentWave].isSequence) await new WaitForSeconds(0.3f);
            }


                await new WaitForSeconds(delay);
        }
    }
}