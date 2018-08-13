using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCountroller : MonoBehaviour {
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //フリッパーアクセス箱
    GameObject Fripper1;
    GameObject Fripper2;

    //TimeTextアクセス箱
    GameObject Timetext;

    //ボール落ちたか
    public bool gameover;

    //canvasアクセス箱
    
    GameObject RetryButton;

    // Use this for initialization
    void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //フリッパー呼び出し
        this.Fripper1 = GameObject.Find("LeftFripper");
        this.Fripper2 = GameObject.Find("RightFripper");

        //Timetext呼び出し
        this.Timetext = GameObject.Find("TimeText");

        this.gameover = false;

        //Canvas呼び出し
        
        this.RetryButton = GameObject.Find("RetryButton");

    }

    // Update is called once per frame
    void Update()
    {
        TimerController timetext1 = Timetext.GetComponent<TimerController>();
        
        
            //ボールが画面外に出た場合
            if (this.transform.position.z < this.visiblePosZ)
            {

                this.gameover = true;

                if (timetext1.totaltime > 0 && timetext1.timeup == false)
                {

                   //GameoverTextにゲームオーバを表示
                   this.gameoverText.GetComponent<Text>().text = "Game Over";

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

                    //retry
                    
                    CanvasController.SetActive("RetryButton", true);
                }

            }
        
        
    }
}