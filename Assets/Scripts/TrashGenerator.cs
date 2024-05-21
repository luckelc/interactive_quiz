using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;
using Random=UnityEngine.Random;

public class TrashGenerator : MonoBehaviour
{
    
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;
    public GameObject trash4;
    public GameObject trash5;
    private float minX = 75f;
    private float maxX = 275f;
    private float rotMin = -100f;
    private float rotMax = 100f;
    private float gravMin = 7;
    private float gravMax = 10; 
    private float scaleMin = 4;
    private float scaleMax = 5;
    private float speedMin = 45;
    private float speedMax = 50;

    void Generate()
    {
        
        // Define random values
        float randomX = Random.Range(minX, maxX);
        Debug.Log(randomX);
        float randomRotationSpeed = Random.Range(rotMin, rotMax);
        Debug.Log(randomRotationSpeed);
        float randomGravity = Random.Range(gravMin, gravMax);
        Debug.Log(randomGravity);
        float randomScale = Random.Range(scaleMin, scaleMax);
        Debug.Log(randomScale);
        float randomSpeed = Random.Range(speedMin, speedMax);
        Debug.Log(randomSpeed);
        // Instantiate the clone
        Vector2 randomPosition = new Vector2(randomX, 700);
        GameObject trash = Instantiate(trash1, randomPosition, Quaternion.identity);
        trash.transform.localScale = new Vector3(randomScale, randomScale, 1);
        // Add a script to handle the rotation of the sprite
        Rotator rotator = trash.AddComponent<Rotator>();
        rotator.rotationSpeed = randomRotationSpeed;
        // Add a Rigidbody2D component to the sprite to enable physics and add movement 
        Rigidbody2D rb = trash.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = new Vector3(0, -randomSpeed, 0);
        Debug.Log(randomGravity);
        rb.gravityScale = randomGravity;
        
        Debug.Log("Initial Velocity: " + rb.velocity);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Generate();
        //Generate();
        //Generate();
        //Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Rotator : MonoBehaviour
{
    // Public variable to set the rotation speed
    public float rotationSpeed;

    void Update()
    {
        // Rotate the sprite around the Z axis at the specified speed
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}