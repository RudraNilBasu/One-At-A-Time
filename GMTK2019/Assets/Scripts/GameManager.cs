using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            int current_scene_index = SceneManager.GetActiveScene().buildIndex;
            if (current_scene_index == 0)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(0); 
            }
        }
    }
}
