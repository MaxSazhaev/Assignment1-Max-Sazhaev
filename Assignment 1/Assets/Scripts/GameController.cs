/* Author: Max Sazhaev
 * File: GameController.cs
 * Creation Date: October 4th 2015
 * Description: This script controls the game's score, restart, end game, and spawning.
 */

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    // Initialize variables

    public GameObject pickup;
    public Vector3 spawnValues;
    public int pickupCount;
    public float spawnWait;
    public float startWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    // Start is called when the script launches
    void Start ()
    {
        // Puts bools to false and makes both texts display nothing.
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        // Starts score at zero and updates
        score = 0;
        UpdateScore();
        // Calls function to Spawn waves
        StartCoroutine (SpawnWaves());
    }

    // Pressing R to restart (load level again) 
    void Update()
    {
        if (restart)
        {
            if(Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    // Spawning Waves
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            // Spawns bombs and wrenches at random x locations
            for (int i = 0; i < pickupCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(pickup, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            //Shows format for Restart and sets restart to true
            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                // Breaks out of the loop
                break;
            }
        }
    }

    // Adds score to existing score
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // Shows format for updated score
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    // Shows format for Game Over and sets bool to true
    public void GameOver ()
    {
        gameOverText.text = "Game Over";
        gameOver = true;

    }
}
