/* Author: Max Sazhaev
 * File: BackgroundMove.cs
 * Creation Date: October 5th 2015
 * Description: This script controls the Background gameObject's movement
 */
using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour 
{
    // Initialize variables
    public float speed;

    // Start is called when the script launches
	void Start () 
    {
        this._Reset();
	}

    // Update is called once per frame
	void Update () 
    {
        Vector2 currentPosition = new Vector2(0.0f, 0.0f);
        currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.y -= speed;

        // Move the gameObject to the currentPosition
        gameObject.GetComponent<Transform>().position = currentPosition;

        // Top boundary check - gameObject meets top of camera viewport
	    if (currentPosition.y <= 1)
        {
            this._Reset();
        }
        
    }

    // Resets our gameObject 
    private void _Reset()
    {
        Vector2 resetPosition = new Vector2(0.0f, 1f);
        gameObject.GetComponent<Transform>().position = resetPosition;
    }
}
