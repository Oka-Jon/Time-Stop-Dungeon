using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMThrough : MonoBehaviour
{ 
     void Awake ()
     {
    GameObject[] objs = GameObject.FindGameObjectsWithTag("BGM");
         if (objs.Length > 1)
             Destroy(this.gameObject);

    DontDestroyOnLoad(this.gameObject);

     }
    
  
}

