/* Author: Max Sazhaev
 * File: DestroyByContactBomb.cs
 * Creation Date: October 4th 2015
 * Description: This script bomb's collider
 */
using UnityEngine;
using System.Collections;

public class DestroyByContactBomb : MonoBehaviour
{
    // Initialize variables
    public int scoreValue;
    private GameController gameController;

    // Start is called when the script launches
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }


    // When happens when the bomb collides
    void OnTriggerEnter(Collider other)
    {
        // If the bomb collides with boundary it does nothing
        if (other.tag == "Boundary")
        {
            return;
        }

        // If the bomb collides with player it shows the Game Over screen
        if (other.tag == "Player")
        {
            gameController.GameOver();
        }
        // Adds score
        gameController.AddScore(scoreValue);

        // Destroys both objects
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
