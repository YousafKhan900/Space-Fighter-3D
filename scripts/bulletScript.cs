using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    Rigidbody rb;
    public float bulletSpeed = 40;
    Vector3 velocity;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        velocity = new Vector3(bulletSpeed,0,0);
        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
