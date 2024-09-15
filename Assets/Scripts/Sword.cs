using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
