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


    public GameObject candyPrefab;


    private float lastMoveTime;

    private List<GameObject> spawnedCandy = new List<GameObject>();

	// Use this for initialization
	void Start () {
        lastMoveTime = Time.time;
        lastTurnTime = Time.time;

        SpawnCandy();
	}
	
	// Update is called once per frame
	void Update () {

        TurnPlayer();

        MovePlayer();

        if (Input.GetKey(KeyCode.Space))
        {
            GrowPlayer();
        }

        CheckIfPlayerAteCandy();
	}

    private void CheckIfPlayerAteCandy()
    {
        if (player != null)
        {
            for(int i = 0; i < spawnedCandy.Count; ++i)
            {
                if (spawnedCandy[i].transform.position == player.head.transform.position)
                {
                    GameObject.Destroy(spawnedCandy[i]);
                    spawnedCandy.RemoveAt(i);

                    SpawnCandy();
                }
            }
        }
    }

    private void SpawnCandy()
    {
        Vector3 candyPosition;

        do
        {
            int x = (int)(UnityEngine.Random.value * 10 - 5),
            y = (int)(UnityEngine.Random.value * 10 - 5),
            z = (int)(UnityEngine.Random.value * 10 - 5);

            candyPosition = new Vector3(x, y, z);
        }
        while (player != null && player.ContainsPoint(candyPosition));

        GameObject candy = GameObject.Instantiate(candyPrefab);

        candy.transform.position = candyPosition;

        candy.transform.rotation = UnityEngine.Random.rotation;

        spawnedCandy.Add(candy);
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
