using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIScript : MonoBehaviour
{
    public Text waveText, scoreText, livesText, fleetWave, gameOver;
    private int waveLevel, score, lives;
    private bool fleetTextFlashed;
    public static bool isGameOver, DestroyCanvas;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        fleetTextFlashed = false;
        isGameOver = false;
        DestroyCanvas = false;
        fleetWave.enabled = false;
        gameOver.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOver.enabled = true;
            StartCoroutine(mainMenuDelay());

        }
        score = asteroidDeployer.score;
        waveLevel = asteroidDeployer.getWaveLevel();
        lives = shipController.playerHealth;
        waveText.text = "wave: " + waveLevel;
        scoreText.text = "score: " + score;
        livesText.text = "lives: " + lives;
        if (waveLevel % 10 == 0 && fleetTextFlashed == false) {
            StartCoroutine(flashFleet());
        }
        if (waveLevel % 10 != 0)
        {
            fleetTextFlashed = false;
        }
    }

    public IEnumerator flashFleet()
    {         
        fleetTextFlashed = true;
        for (int i = 0; i < 5; i++)
        {
            fleetWave.enabled = true;
            yield return new WaitForSeconds(.5f);
            fleetWave.enabled = false;
            yield return new WaitForSeconds(.5f);
        }
        
    }

    public IEnumerator mainMenuDelay()
    {
        yield return new WaitForSeconds(6);
        DestroyCanvas = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

}
