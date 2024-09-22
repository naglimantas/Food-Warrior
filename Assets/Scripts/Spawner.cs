using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;

    void Start()
    {
        Spawn();
    }

    async void Spawn()
    {
        while (true)
        {
            await new WaitForSeconds(Random.Range(0.5f,2f));
            GameObject obj = prefabs[Random.Range(0, prefabs.Length)];
            Vector3 pos = transform.position + Vector3.right * Random.Range(-5f, 5f);
            Instantiate(obj, pos, Quaternion.identity);
        }
    }
}