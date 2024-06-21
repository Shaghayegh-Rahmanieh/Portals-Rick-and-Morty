using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    public Image[] hearts;
    public GameManager gamemanager;
    int lives;
        
    void Start()
    {
          // دریافت مقدار متغیر جون ها از اسکریپت گیم منیجر
          lives=gamemanager.live;
    }

  
    void Update()
    {
           //بررسی جون ها و کم کردن قلب ها با توجه به ان
          lives=gamemanager.live;
        if(lives<=2)
          hearts[0].enabled=false;
            if(lives<=1)
          hearts[1].enabled=false;
             if(lives<=0)
          hearts[2].enabled=false;

          
         
       
    }
}
