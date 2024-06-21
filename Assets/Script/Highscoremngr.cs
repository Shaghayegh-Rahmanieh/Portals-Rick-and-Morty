using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Highscoremngr : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI Highscoretxt;
    public TextMeshProUGUI scoretxt;
      public int highscore;
      int myscore;
     

    void Start()
    {
        //دریافت پلیرپرفس های امتیاز و بیشترین امتیاز
       myscore= PlayerPrefs.GetInt("yourscore");
        highscore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        //اگر امتیاز کسب شده بیشتر از بیشترین امتیاز باشد در ان ذخیره می شود
        //همچنین نشان دادن امتیاز و بیشترین امتیاز 
        Highscoretxt.text = "High Score: " + highscore.ToString();
        if (gameManager.score > highscore)
        {
            highscore = gameManager.score;
            PlayerPrefs.SetInt("HighScore", highscore);
        }
         scoretxt.text="Score:"+myscore.ToString();
      


    }
}
