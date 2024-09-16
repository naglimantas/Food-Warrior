using UnityEngine;

public class Audio : MonoBehaviour
{
    public static AudioSource source;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public static void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}