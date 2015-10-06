/* Author: Max Sazhaev
 * File: DestroyByBoundary.cs
 * Creation Date: October 4th 2015
 * Description: This script controls the Boundary's collider
 */
using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
    // When happens when the something exits the boundary
    void OnTriggerExit(Collider other)
    {
        // Delete only the other object
        Destroy(other.gameObject);
    }
}
