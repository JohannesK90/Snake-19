using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Movement : MonoBehaviour
{
    #region Variables

    
    GameState gameState;
    ScoreCounter scoreCounter;

    LinkList linkList;

    Vector2 direction = Vector2.right;

    public GameObject foodPrefab;
    public GameObject tailObj;
    GameObject food;

    public float snakeSpeed = 0.3f;
    public bool snakeAte = false;
    float tick = 0;

    Vector2 snakeOldPos;

    public enum eDirection
    {
        up,
        right,
        down,
        left
    };

    public eDirection snakeDirection;
    #endregion

    void Awake()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        gameState = FindObjectOfType<GameState>();
        linkList = new LinkList(); //declare the linklist.
        linkList.AddFirst(gameObject); //Add a frist node in the linklist with the tail prefab.
        food = Instantiate(foodPrefab, new Vector2(2,2), Quaternion.identity);
    }

    void Update()
    {
        PlayerInput();
        if(tick > snakeSpeed)
        {
            Move();
            tick = 0;
        }

        tick += Time.deltaTime;

    }

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && snakeDirection != eDirection.left)
        {
            direction = Vector2.right;
            snakeDirection = eDirection.right;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && snakeDirection != eDirection.up)
        {
            direction = Vector2.down;
            snakeDirection = eDirection.down;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) && snakeDirection != eDirection.right)
        {
            direction = Vector2.left;
            snakeDirection = eDirection.left;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && snakeDirection != eDirection.down)
        {
            direction = Vector2.up;
            snakeDirection = eDirection.up;
        }
    }

    void Move()
    {
        snakeOldPos = transform.position;

        if (snakeAte)
        {
            GameObject go = Instantiate(tailObj, snakeOldPos, Quaternion.identity, transform.parent);
            if (linkList.Count > 1)
            {
                linkList.InsertAfter(linkList.head.next, go);
            }
            else
            {
                linkList.Addlast(go);
            }
            snakeAte = false;
        }

        else if(linkList.Count > 1)
        {
            Node temp = linkList.GetLastNode();
            if (temp != null)
            {
                temp.gameObjData.transform.position = snakeOldPos;
                linkList.RemoveLast();
                linkList.InsertAfter(linkList.head.next, temp.gameObjData);
            }
        }

            transform.Translate(direction);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            snakeAte = true;
            scoreCounter.scoreValue++;
            Debug.Log("Food hit");
        }
        else
        {
            gameState.resetTrue = true;
            gameState.GameOver();
        }
    }
}