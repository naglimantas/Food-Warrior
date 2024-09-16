using UnityEngine;

public class Fruit : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12f);
    }

}