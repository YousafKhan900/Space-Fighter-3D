using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleetShipScript : MonoBehaviour
{
    public GameObject bulletReference;
    private Rigidbody rb;
    private bool canShoot;
    private float health;
    private static int numberOfShips;
    void Start()
    {
        canShoot = true;
        health = 150;
        numberOfShips = 5;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * 0.05f;
        if (canShoot)
        {
            canShoot = false;
            shootBullet();
            StartCoroutine(bulletDelay());
        }

        if (Camera.main.WorldToViewportPoint(transform.position).x < -0.1)
        {
            numberOfShips--;
            if (numberOfShips == 0)
            {
                FleetDeployer.setAllShipsDestroyed(true);

            }
            Destroy(gameObject);
        }
      
    }

    private void shootBullet()
    {
        GameObject bullet = GameObject.Instantiate(bulletReference);
        bullet.transform.position = transform.position + Vector3.left*7.8f;
    }

    IEnumerator bulletDelay() {
        yield return new WaitForSeconds(Random.Range(0.2f, 3));
        canShoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            health -= 10f;
            if(health <= 0)
            {
                asteroidDeployer.score += 300;
                numberOfShips--;
                if(numberOfShips == 0)
                {
                    FleetDeployer.setAllShipsDestroyed(true);

                }
                Destroy(gameObject); 
            }
        }

    }
}
