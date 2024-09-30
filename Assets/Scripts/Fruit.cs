using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    public AudioClip splashSound;
    public ParticleSystem splashParticles;
    public Color splashColor;
    public bool isBomb;
    public string nextSceneName;

    void Update()
    {
        if (transform.position.y < -7 && !isBomb)
        {
            GameManager.instance.Damage(1);
            Destroy(gameObject);
        }
    }

    public void Slice()
    {
        Audio.Play(splashSound);
        if (isBomb)
        {
            GameManager.instance.Damage(3);
        }
        else
        {
            GameManager.instance.AddScore(1);
        }

        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child == transform) continue;

            Rigidbody2D rb = child.gameObject.AddComponent<Rigidbody2D>();
            rb.velocity = GetComponent<Rigidbody2D>().velocity + Random.insideUnitCircle * 5f;
            rb.angularVelocity = Random.Range(-10f, 10f);
        }

        ParticleSystem particles = Instantiate(splashParticles, transform.position, Quaternion.identity);
        particles.startColor = splashColor;

        transform.DetachChildren();
        Destroy(gameObject);

        if (nextSceneName != "Gameplay")
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}