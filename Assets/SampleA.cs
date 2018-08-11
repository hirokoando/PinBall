using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleA : MonoBehaviour {

    //タッチの座標入れ
    private Vector2 m_TouchPos1;
    //座標原点
    Vector2 Vorigin = new Vector2(0.0f, 0.0f);


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            m_TouchPos1 = touch.position;


                Debug.Log("origin x" + Vorigin.x
                    + " y" + Vorigin.y);

                Debug.Log("m_TouchPos1 x" + m_TouchPos1.x
                    + " y" + m_TouchPos1.y);



        }
        
           

    }

}
