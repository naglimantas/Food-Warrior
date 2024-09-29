using UnityEngine;

public class Fruit : MonoBehaviour
{
    public AudioClip splashSound;
    public ParticleSystem splashParticles;
    public Color splashColor;
    public bool isBomb;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12f);
    }

    public void Slice()
    {
        Audio.Play(splashSound);
        if (isBomb)
        {
            print(":(");
        }

        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if(child == transform) continue;

            Rigidbody2D rb = child.gameObject.AddComponent<Rigidbody2D>();
            rb.velocity = GetComponent<Rigidbody2D>().velocity + Random.insideUnitCircle * 5f;
            rb.angularVelocity = Random.Range(-10f, 10f);
        }

        ParticleSystem particles = Instantiate( splashParticles, transform.position, Quaternion.identity );
        particles.startColor = splashColor;

        transform.DetachChildren();
        Destroy(gameObject);
    }
}