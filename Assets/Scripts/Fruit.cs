using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public AudioClip splashSound;
    public ParticleSystem splashParticles;
    public Color splashColor;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12f);
    }

    public void Slice()
    {
        Audio.Play(splashSound);
        foreach (Transform child in GetComponentInChildren<Transform>())
        {
            if (child == transform) continue;

            Rigidbody2D rb = child.gameObject.AddComponent<Rigidbody2D>();
            rb.velocity = GetComponent<Rigidbody2D>().velocity + Random.insideUnitCircle * 5f;
            rb.angularVelocity = Random.Range(-10f, 10f);
        }

        Instantiate(splashParticles, transform.position, Quaternion.identity);
        splashParticles.startColor = splashColor;

        transform.DetachChildren();
        Destroy(gameObject);
    }
}
