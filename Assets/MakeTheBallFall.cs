using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTheBallFall : MonoBehaviour {


    public float waitDuration = 1f;

    private float lastDropTime;

	// Use this for initialization
	void Start () {
        lastDropTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        float now = Time.time;

        if (now - lastDropTime >= waitDuration)
        {
            gameObject.transform.position += Vector3.down;

            lastDropTime = now;
        }

        
		
	}
}
