using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour {

    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;


    //タッチの座標入れ
    private Vector2 m_TouchPos1;
    private Vector2 m_TouchPos2;

    //スクリーン座標x画面サイズの中心
    Vector2 Vorigin = new Vector2(Screen.width / 2, 0.0f);

    //フりっぱー機能すいっち
    public bool gameplay;



    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

        //フりっぱー機能すいっち
        gameplay = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameplay == true)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {

                    Touch touch = Input.GetTouch(i);

                    m_TouchPos1 = touch.position;



                    if (touch.phase == TouchPhase.Began)
                    {
                        // タッチ開始

                        //left
                        if (Vorigin.x > m_TouchPos1.x && tag == "LeftFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }

                        //right
                        if (Vorigin.x < m_TouchPos1.x && tag == "RightFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }


                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        // タッチ終了

                        //left
                        if (tag == "LeftFripperTag")
                        {
                            SetAngle(this.defaultAngle);
                        }

                        //right
                        if (tag == "RightFripperTag")
                        {
                            SetAngle(this.defaultAngle);
                        }
                    }
                }
            }
        }
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

   
}
