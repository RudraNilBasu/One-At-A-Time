using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIntroText : MonoBehaviour
{
    bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !done)
        {
            done = true;
            gameObject.GetComponent<Animation>().Play("TextFade");
        }
    }
}
