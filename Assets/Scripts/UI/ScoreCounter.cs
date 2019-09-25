using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int scoreValue;

    Movement moveCol;
    Text score;

    // Start is called before the first frame update
    void Awake()
    {
        moveCol = FindObjectOfType<Movement>();
        score = GetComponent<Text>();
    }

    public void Update()
    {
        score.text = scoreValue.ToString();
    }
}
