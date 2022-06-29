using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{
    public float speed = 20.0f;
    public GameObject bulletReference;
    public static int playerHealth;
    public float bulletDelay = 0.2f;
    private bool hasCollide = false, canShoot = true;
    private GameObject explosion;

    void Start()
    {
        playerHealth = 3;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.position = transform.position + Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + Vector3.down * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                shootBullet();
                canShoot = false;
                StartCoroutine(shootDelay());
            }
        }
    }

    private void LateUpdate()
    {
        hasCollide = false;
        if (playerHealth <= 0) {
            explosion = (GameObject)GameObject.Instantiate(Resources.Load("Explosion 1"));
            explosion.transform.position = transform.position;
            explosion.transform.localScale = transform.localScale * 2;
            Destroy(gameObject);
            GUIScript.isGameOver = true;
        }
    }

    void shootBullet()
    {
        GameObject bullet1 = GameObject.Instantiate(bulletReference);
        GameObject bullet2 = GameObject.Instantiate(bulletReference);
        bullet1.transform.position = transform.position + new Vector3(4,3.1f,1);
        bullet2.transform.position = transform.position + new Vector3(4, -3.1f, 1);
    }

    IEnumerator shootDelay() {
        yield return new WaitForSeconds(bulletDelay);
        canShoot = true;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasCollide == false)
        {
            hasCollide = true;
            transform.position = transform.position + Vector3.left * 2f;
            playerHealth--;
        }
       
    }

 
}


