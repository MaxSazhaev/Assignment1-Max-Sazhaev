/* Author: Max Sazhaev
 * File: DestoryByContact.cs
 * Creation Date: October 4th 2015
 * Description: This script controls the wrench's collision
 */
using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
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

    // When happens when the wrench collides
    void OnTriggerEnter(Collider other)
    {
        // If the wrench collides with boundary it does nothing
        if (other.tag == "Boundary")
        {
            return;
        }
        // Adds score
        gameController.AddScore(scoreValue);
        // Destroys only wrench
        Destroy(gameObject);
    }
}
