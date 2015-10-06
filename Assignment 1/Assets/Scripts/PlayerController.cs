/* Author: Max Sazhaev
 * File: PlayerController.cs
 * Creation Date: October 4th 2015
 * Description: This script controls the Background gameObject's movement
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
// Sets boundary settings
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
    // Initialize variables and audio
    private AudioSource[] _audioSources;
    private AudioSource _bombAudio, _wrenchAudio, _catAudio;
    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    // Start is called when the script launches
    void Start() 
    {
        // Readys audio
        this._audioSources = this.GetComponents<AudioSource>();
        this._wrenchAudio = this._audioSources [1];
        this._bombAudio = this._audioSources [2];
        this._catAudio = this._audioSources[3];
    }

    void Update ()
    {
        // Spawns bullet when press mouse 1
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            // Plays cat audio
            this._catAudio.Play();
        }
    }
    void FixedUpdate ()
    {
        // Moves player
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        // Sets boundary for player
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
    }
    // When happens when the player collides
    void OnTriggerEnter(Collider otherGameObject)
    {
        // Player collision with wrench
        if (otherGameObject.tag == "Wrench")
        {
            this._wrenchAudio.Play();
        }
        // Player collision with bomb
        if (otherGameObject.tag == "Bomb")
        {
            this._bombAudio.Play();
        }
    }
}
