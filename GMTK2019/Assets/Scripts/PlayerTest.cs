﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public GameObject P1, P2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Player 1 apparent speed: " + P1.GetComponent<PlayerMotor>().normalPlayerSpeed);
        // Debug.Log("Player 1 Speed: " + P1.GetComponent<Rigidbody2D>().velocity + "Player 2 Speed: " + P2.GetComponent<Rigidbody2D>().velocity);
    }
}
