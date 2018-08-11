using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private GameObject gameoverText;
    GameObject TimeText;
    public float totaltime;
    int seconds;
    int minutes;

    GameObject Fripper1;
    GameObject Fripper2;
    GameObject Ball;

    public bool timeup;


    void Start()
    {
        this.timeup = false;

        //テキスト呼び出し
        this.TimeText = GameObject.Find("TimeText");
        this.gameoverText = GameObject.Find("GameOverText");

        //フリッパー呼び出し
        this.Fripper1 = GameObject.Find("LeftFripper");
        this.Fripper2 = GameObject.Find("RightFripper");

        this.Ball = GameObject.Find("Ball");
    }

    void Update()
    {
        // 毎フレーム毎に残り時間を減らしてく
        this.totaltime -= Time.deltaTime;

        //ボールコントローラー呼び出し
        BallCountroller ballcon = this.Ball.GetComponent<BallCountroller>();
       
        if (this.totaltime < 0)
        {
            if (ballcon.gameover == false)
            {
                this.timeup = true;

                this.gameoverText.GetComponent<Text>().text = "Time Up";

                //フリッパー付属スクリプト呼び出しと変数変更PC
                FripperController fripper1 = this.Fripper1.GetComponent<FripperController>();
                fripper1.gameplay = false;

                FripperController fripper2 = this.Fripper2.GetComponent<FripperController>();
                fripper2.gameplay = false;

                //フリッパー付属スクリプト呼び出しと変数変更Android
                TouchSystem fripper11 = this.Fripper1.GetComponent<TouchSystem>();
                fripper11.gameplay = false;

                TouchSystem fripper22 = this.Fripper2.GetComponent<TouchSystem>();
                fripper22.gameplay = false;
            }

        }
        else
        {
            // timeを文字列に変換したものをテキストに表示する
            minutes = (int)totaltime / 60;
            seconds = (int)totaltime - minutes * 60;

            
            this.TimeText.GetComponent<Text>().text = this.minutes.ToString("00") +":" + this.seconds.ToString("00");
        }


    }
}


