using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private GameObject ScoreText;
    private int sumScore;
    
    // Use this for initialization
    void Start () {
        this.ScoreText = GameObject.Find("ScoreText");
        sumScore = 0;
    }
	
	// Update is called once per frame
	void Update () {
       
        this.ScoreText.GetComponent<Text>().text = "Score:" + sumScore;
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "LargeStarTag")
        {
            sumScore += 5;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            sumScore += 1;
        }

    }

}
