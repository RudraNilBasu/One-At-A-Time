using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
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
            col.gameObject.GetComponent<Animation>().Play("death_anim_test_1");
            StartCoroutine(WaitAndLoad());
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
