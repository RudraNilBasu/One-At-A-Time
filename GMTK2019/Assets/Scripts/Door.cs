﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    Fading fading_go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            fading_go.BeginFade(1);
            GetComponent<Animation>().Play("end_anim_test_1");
            col.gameObject.GetComponent<Animation>().Play("end_anim_test_1");
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(0.1f);
        if (SceneManager.GetActiveScene().buildIndex != 5) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        } else {
        SceneManager.LoadScene(0); 
        }
    }
}
