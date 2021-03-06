﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    SpriteRenderer sprite;

    [SerializeField]
    Animation circle_anim;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -20.0f) {
            Die();
            StartCoroutine(WaitAndLoad());
        }
        
    }

    public void Die()
    {
        sprite.enabled = false;
        circle_anim.Play("death_anim_test_2");
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
