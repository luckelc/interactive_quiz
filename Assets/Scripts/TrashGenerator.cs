using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;
using Random=UnityEngine.Random;

public class TrashGenerator : MonoBehaviour
{
    public float minX = 75f;
    public float maxX = 275f;
    public float rotMin = -100f;
    public float rotMax = 100f;
    public float gravMin = 4f;
    public float gravMax = 5f; 
    public float scaleMin = 2f;
    public float scaleMax = 3f;
    public float speedMin = -1000000000f;
    public float speedMax = -1200000000f;
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;
    public GameObject trash4;
    public GameObject trash5;
    public GameObject trash6;

    void Generate()
    {
        // Define random values
        float randomX = Random.Range(minX, maxX);
        float randomRotationSpeed = Random.Range(rotMin, rotMax);
        float randomGravity = Random.Range(gravMin, gravMax);
        float randomScale = Random.Range(scaleMin, scaleMax);
        float randomSpeed = Random.Range(speedMin, speedMax);
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
        rb.gravityScale = randomGravity;
        rb.velocity = new Vector2(0, -randomSpeed);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Generate();
        Generate();
        Generate();
        Generate();
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