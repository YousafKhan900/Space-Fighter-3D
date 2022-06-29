using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 20f;
    public float tumble = 5;
    public float asteroidHealth = 10f;
    private GameObject explosion;
    private Vector3 viewPos;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.left * speed;
        rb.angularVelocity = Random.insideUnitSphere * tumble;

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        viewPos = transform.position;
        viewPos = Camera.main.WorldToViewportPoint(viewPos);
        if (viewPos.x < -0.1) {
            Destroy(gameObject);
        }
        if (asteroidHealth <= 0) {
            explosion = (GameObject)GameObject.Instantiate(Resources.Load("Explosion 1"));
            explosion.transform.position = transform.position;
            explosion.transform.localScale = transform.localScale * 1.3f;
            Destroy(gameObject);
            asteroidDeployer.incrementNumberOfAsteroidsDestroyed();
            switch (gameObject.name) {
                case "Asteroid 1(Clone)":
                    asteroidDeployer.score += 10;
                    break;
                case "Asteroid 2(Clone)":
                    asteroidDeployer.score += 30;
                    break;
                case "Asteroid 3(Clone)":
                    asteroidDeployer.score += 50;
                    break;
                case "Asteroid Lava Red(Clone)":
                    asteroidDeployer.score += 150;
                    break;
                case "Asteroid Lava Blue(Clone)":
                    asteroidDeployer.score += 100;
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)") {
            asteroidHealth = asteroidHealth - 10f;
        }
        if (collision.gameObject.name == "MainFighter(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
