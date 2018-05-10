using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float moveTimer = 0.5f,
                 turnDelay = 0.25f;

    public PlayerController player;

    public KeyCode turnLeft = KeyCode.LeftArrow, 
        turnRight = KeyCode.RightArrow, 
        turnDown = KeyCode.DownArrow, 
        turnUp = KeyCode.UpArrow;

    private float lastMoveTime;

	// Use this for initialization
	void Start () {
        lastMoveTime = Time.time;
        lastTurnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        TurnPlayer();

        MovePlayer();

        if (Input.GetKey(KeyCode.Space))
        {
            GrowPlayer();
        }
	}

    private void GrowPlayer()
    {
        if (player != null)
        {
            player.Grow();
        }
    }

    float lastTurnTime;
    private void TurnPlayer()
    {
        float now = Time.time;
        if (player != null && (now - lastTurnTime) >= turnDelay)
        {
            Vector3 turn = Vector3.zero;

            if (Input.GetKey(turnLeft))
            {
                turn += Vector3.left;
            }

            if (Input.GetKey(turnRight))
            {
                turn += Vector3.right;
            }

            if (Input.GetKey(turnDown))
            {
                turn += Vector3.down;
            }

            if (Input.GetKey(turnUp))
            {
                turn += Vector3.up;
            }

            if (turn != Vector3.zero)
            {
                lastTurnTime = now;

                player.Turn(turn);
            }
        }
        
    }

    private void MovePlayer()
    {
        if (player != null)
        {
            float now = Time.time;

            if (now - lastMoveTime >= moveTimer)
            {
                player.MoveForward();
                lastMoveTime = now;
            }
        }
    }
}
