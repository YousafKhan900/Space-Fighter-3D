using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGameScript : MonoBehaviour
{
    public GameObject mainFighter, asteroidDeployer, canvasObj;
    void Start()
    {
        Instantiate(canvasObj);
        Instantiate(mainFighter);
        Instantiate(asteroidDeployer);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
