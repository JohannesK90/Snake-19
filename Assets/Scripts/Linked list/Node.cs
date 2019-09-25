using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public GameObject gameObjData;
    public Node next;

    public Node(GameObject data)
    {
        gameObjData = data;
        next = null;
    }

}
