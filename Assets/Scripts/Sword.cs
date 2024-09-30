using UnityEngine;

public class Sword : MonoBehaviour
{
    public AudioClip splashSound;
    Camera cam;
    public float sliceTime;
    public float maxComboTime;
    public int combo;

    [SerializeField] AudioClip[] comboSounds;

    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;


        //COMBO REWARD
        if (Time.time - sliceTime >= maxComboTime && combo >= 3)
        {
            GameManager.instance.AddScore(combo);
            Audio.Play(comboSounds[combo - 3]);
            combo = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Audio.Play(splashSound);
        other.gameObject.GetComponent<Fruit>().Slice();

        //COMBO INCREASE
        if (Time.time - sliceTime < maxComboTime)
        {
            combo++;
        }
        else
        {
            print(combo);
            combo = 1;
        }
        sliceTime = Time.time;
    }
}