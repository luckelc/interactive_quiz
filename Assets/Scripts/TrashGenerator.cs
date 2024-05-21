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
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;
    public GameObject trash4;
    public GameObject trash5;
    public GameObject trash6;

    void Generate()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 randomPosition = new Vector2(randomX, 700);
        GameObject trash = Instantiate(trash1, randomPosition, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
