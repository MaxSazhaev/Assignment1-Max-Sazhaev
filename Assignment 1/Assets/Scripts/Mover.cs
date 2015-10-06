/* Author: Max Sazhaev
 * File: Mover.cs
 * Creation Date: October 4th 2015
 * Description: This script controls the movement of bombs and wrenches
 */

using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
   // Initialize variable
    public float speed;

    // Start is called when the script launches
    void Start ()
    {
        // Moves different objects down
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
