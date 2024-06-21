
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Sceneloadgame : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    // رفتن به سین بعدی با تابع ان کلیک 
    public void nextscene()
    {
         SceneManager.LoadScene("Game");

    }
}


    



