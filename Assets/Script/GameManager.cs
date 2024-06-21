using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


// ((((((:

public class GameManager : MonoBehaviour
{
    public Color colorToPick;
    public Image[] img;
  
    int[] arraysOfNums = {0, 1, 2, 3, 4, 5, 6, 7};
    Dictionary<string, Color> colors;
    public TextMeshProUGUI pickTxt;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI timertxt;
    [SerializeField] List<AudioSource> sounds=new List<AudioSource>();
      
    public int score = 0;
    public int live = 3;
    public int highscore;
    private float timer = 3.0f;

    void Start()
    {
        //ایجاد پلیر پرفس برای ذخیره امتیاز و نشون دادن در سین بعدی
         PlayerPrefs.SetInt("yourscore", 0);
         
         //اضافه کردن رنگ ها
        colors = new Dictionary<string, Color>();
        colors.Add("Blue", Color.blue);
        colors.Add("Magenta", Color.magenta);
        colors.Add("Green", Color.green);
        colors.Add("Cyan", Color.cyan);
        colors.Add("Red", Color.red);
        colors.Add("Gray", Color.gray); 
        colors.Add("Yellow", Color.yellow);
        colors.Add("White", Color.white); 

        //دریافت ایمیج های زیر مجموعه والد یعنی کنوس
        img = GetComponentsInChildren<Image>();

        //اعمال رنگ رندوم
        SetupColors();
        SetupText(); 
    }

    void Update()
    {
        //اعمال تامیر سه ثانیه ای
        timer -= Time.deltaTime;
        timertxt.text = ": " + Mathf.Ceil(timer).ToString();

        // اگر سه ثانیه تمام شود و کاربر چیزی انتخاب نکند از جون ها کم میشه 
        if (timer <= 0)
        {
            timer = 3.0f;
            live--;
                sounds[0].Play();
              //اگر جون ها بیشتر از 3 بود میره مرحله بعد وگرنه میبازه
            if (live > 0)
            {
                SetupColors();
                SetupText();
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }    
        }       
       
       
    }

    public void SetupText() 
    {
        //دریافت یک عدد رندوم و انتخاب رندوم از لیست یا ارایه
        //برای رنگ و متن 
        int rand = UnityEngine.Random.Range(0, colors.Count); 
        pickTxt.text = colors.ElementAt(rand).Key;
        colorToPick = colors.ElementAt(rand).Value;
        pickTxt.color = SetColor(UnityEngine.Random.Range(0, 8)); 
    }

    public void SetupColors()
    {
        //دریافت رندوم اعداد رندوم برای اعمال رنگ ها
        img = GetComponentsInChildren<Image>();
        arraysOfNums = arraysOfNums.OrderBy(i => UnityEngine.Random.Range(0, img.Length)).ToArray(); // Specified UnityEngine.Random
        int newNum = 0;
        foreach (Image image in img)
        {
            if (image != null) 
            {
                image.color = SetColor(arraysOfNums[newNum]); 
                newNum++;
            }
        }
    }

    public Color SetColor(int numInArray)
    {
         //اعمال رنگ های رندوم
        switch (numInArray)
        {
            case 0:
                return Color.blue;
            case 1:
                return Color.magenta;
            case 2:
                return Color.green;
            case 3:
                return Color.cyan;
            case 4:
                return Color.red;
            case 5:
                return Color.gray; 
            case 6:
                return Color.yellow;
            case 7:
                return Color.white; 
            default:
                return Color.clear;
        }
    }

    public void CheckColor(Image image)
    {
        //دریاف مقدار ورودی با تابع آن کلیک 
        //بررسی درست بودن یا غلط بودن آن
        if (image.color == colorToPick)
        {
              sounds[1].Play();
            SetupColors();
            SetupText();
            score++;
            scoreTxt.text = "Score: " + score;
            timer = 3.0f; 
             PlayerPrefs.SetInt("yourscore", score);
              PlayerPrefs.Save();
        }
         else
        {
            sounds[0].Play();
            live--;
          

            if (live <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    
        SetupColors();
        SetupText();
       
    }
}