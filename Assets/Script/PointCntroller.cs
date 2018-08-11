using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCntroller : MonoBehaviour {

    private GameObject pointText;
    private int sumPoint;
    private int point;
    private int judge;
    

    // Use this for initialization
    void Start () {

        this.pointText = GameObject.Find("PointText");
        sumPoint = 0;
        judge = 0;

        if (tag == "SmallStarTag")
        {
            this.point = 0;
        }
        else if (tag == "LargeStarTag")
        {
            this.point = 5;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.point = 1;
        }



    }
	
	// Update is called once per frame
	void Update () {

       if (judge == 1)
       {
            sumPoint += point;
            judge = 0;
       }

        this.pointText.GetComponent<Text>().text = "Point:" + sumPoint;

    }

    void OnCollisionEnter(Collision other)
    {
        judge = 1;

    }

}
