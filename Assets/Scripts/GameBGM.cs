using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.mute = false;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            if (audio.mute == true)
            {
              
                audio.mute = false;
            }
            else
            {
                
                audio.mute = true;
            }
                audio.volume = 0.5f;
        }

    }
}

