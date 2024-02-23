using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string name;
    private int exitNum;

    public Room(string name)
    {
        this.name = name;
        this.exitNum = (int)Random.Range(1.0f, 4.0f);        
    }

    public int getExitNum()
    {
        return this.exitNum;
    }

    public void display()
    {
        Debug.Log(this.exitNum);
    }
}
