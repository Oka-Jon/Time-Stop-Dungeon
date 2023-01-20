using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesCount : MonoBehaviour
{
    public int lifeCount = 5;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
        
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScreen")
        {
            Destroy(this.gameObject);
        }
    }

}
