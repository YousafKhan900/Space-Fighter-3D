using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetDeployer : MonoBehaviour
{
    public GameObject fleetShip;
    List<GameObject> ships;
    private static bool allShipsDestroyed = false;
    void Start()
    {
        ships = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            ships.Add(Instantiate(fleetShip));
        }
        ships[0].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0.5f, 45f));
        ships[1].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.15f, 0.3f, 45f));
        ships[2].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.15f, 0.7f, 45f));
        ships[3].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.9f, 45f));
        ships[4].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.1f, 45f));

    }

    // Update is called once per frame
    void Update()
    {
        if (allShipsDestroyed)
        {
            asteroidDeployer.incrementWaveLevel();
            Destroy(gameObject);
        }
    }

    public static void setAllShipsDestroyed(bool val)
    {
        allShipsDestroyed = val;
    }
}
