using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkList
{

    public Node head;
    private Node Last;

    public int Count//Build an indexer to keep track of the nodes.
    {
        get; private set;
    }

    public void AddFirst(GameObject data)
    {
        Node newNode = new Node(data);//creat a new node.
        newNode.next = head;//The new node points at one after head.
        head = newNode;//Make the head pint at the new node.
        Count++;// Add to the index 
    }

    public void Addlast(GameObject data)
    {
        Node newNode = new Node(data);//creat a new node.
        if (head != null)//Check if the head is not the last node.
        {
            Node lastNode = GetLastNode();//Store the last node in our list as "lastNode".
            lastNode.next = newNode;// "newNode" is now the last node in the list.
        }
        else
        {
            head = newNode;//Otherwise newNode will be the head node.
        }
        Count++;
    }

    public Node GetLastNode()
    {
        Node temp = head;// Make an tempoaraie node.
        while (temp.next != null)//Check to see if temp is not pointing to null.
        {
            temp = temp.next;//If it's not pointing to null move to the next node.
        }
        return temp;//
    }

    public void InsertAfter(Node prevNode, GameObject data)
    {
        if (prevNode == null)
        {
            Debug.Log("Null ref insertAfter");

        }
        Node newNode = new Node(data);//creat a new node.
        newNode.next = prevNode.next;//newNode points at the next node which is prevNode next node.
        prevNode.next = newNode;//Then we will make prevNode point at the new node
        Count++;//Add 1 to index
    }

    public Node RemoveLast()
    {
        return RemoveLast(head, Count);
    }

    Node RemoveLast(Node node, int nodesleft)
    {
        if (nodesleft == 1)//Check to see if there only one value in the index.
        {
            Node temp = Last;//creat a new node.
            Last = node;
            node.next = null;//Make the node point att null.
            Count--;//Then take away one value from the index.
            return temp;
        }
        else
        {
            return RemoveLast(node.next, nodesleft - 1);//Otherwise remove the last nodew and removne for the index.
        }
    }

}