using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private GameObject ScoreText;
    GameObject Playtext;
    private int sumScore;

    public float lifetime;
    float nowtime;

    // Use this for initialization
    void Start () {
        this.ScoreText = GameObject.Find("ScoreText");
        this.Playtext = GameObject.Find("PlayText");
        sumScore = 0;
    }
	
	// Update is called once per frame
	void Update () {
       
        this.ScoreText.GetComponent<Text>().text = "Score:" + sumScore;

       
        if(sumScore >= 30)
        {
            this.Playtext.GetComponent<Text>().text = "Fantastic!";
        }else if(sumScore >= 20){
            this.Playtext.GetComponent<Text>().text = "Grate!";
        }else if(sumScore>= 10)
        {
            this.Playtext.GetComponent<Text>().text = "Nice!";
        }
        else
        {
            this.Playtext.GetComponent<Text>().text = " ";
        }
            
         
       

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
