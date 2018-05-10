using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public GameObject head, tail;
    public GameObject bodyPrefab;

    private List<GameObject> bodyPieces = new List<GameObject>();

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveForward()
    {
        Vector3 position = head.transform.position;
        Vector3 nextPosition;
        foreach(var bodyPart in bodyPieces)
        {
            nextPosition = bodyPart.transform.position;

            bodyPart.transform.position = position;

            position = nextPosition;
        }

        tail.transform.position = position;

        head.transform.Translate(Vector3.forward);
    }

    public void TurnLeft()
    {
        Turn(Vector3.left);
    }

    public void TurnRight()
    {
        Turn(Vector3.right);
    }

    public void TurnUp()
    {
        Turn(Vector3.up);
    }

    public void TurnDown()
    {
        Turn(Vector3.down);
    }

    public void Turn(Vector3 direction)
    {
        // left/right --> rotation over y axis
        // up/down --> rotation over x axis
        Vector3 r = new Vector3(direction.y * -90, direction.x * 90);

        head.transform.Rotate(r);

        //head.transform.Rotate(direction);
    }

    public void Grow(int count)
    {
        GameObject newPiece;
        Vector3 position = tail.transform.position;
        for(int i = 0; i < count; ++i)
        {
            newPiece = GameObject.Instantiate(bodyPrefab, position, this.transform.rotation, this.gameObject.transform);
            bodyPieces.Add(newPiece);
            position += Vector3.back;
        }

        tail.transform.position = position;
    }

    public void Grow()
    {
        Grow(1);
    }
}
