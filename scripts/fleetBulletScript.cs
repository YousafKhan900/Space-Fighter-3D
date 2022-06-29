using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleetBulletScript : MonoBehaviour
{
    Rigidbody rb;
    public float bulletSpeed = 40;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        velocity = new Vector3(-bulletSpeed, 0, 0);
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
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
