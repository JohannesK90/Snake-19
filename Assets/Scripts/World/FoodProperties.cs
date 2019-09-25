using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProperties : MonoBehaviour
{
    public GameObject FoodObject;

    public int Xmax;
    public int Xmin;
    public int Ymax;
    public int Ymin;

    int x;
    int y;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        int x = (int)Random.Range(Xmax, Xmin);

        int y = (int)Random.Range(Ymax, Ymin);

        FoodObject.transform.position = new Vector2(x, y);
    }
}
