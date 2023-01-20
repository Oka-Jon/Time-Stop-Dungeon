using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotTreasure : MonoBehaviour
{
    AudioSource audioTreasure;

    private void Start()
    {
        audioTreasure = GameObject.Find("audioTreasure").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioTreasure.Play();
            print("Win");
            SceneManager.LoadScene("StartScreen");
        }
    }
}
