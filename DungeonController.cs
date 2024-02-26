using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject[] closedDoors;

    private string mapIndexToStringForExit(int index)
    {
        if(index == 0)
        {
            return "north";
        }
        else if (index == 1)
        {
            return "south";
        }
        else if (index == 2)
        {
            return "east";
        }
        else if (index == 3)
        {
            return "west";
        }
        else
        {
            return "?";
        }
    }
    void Start()
    {
        MySingleton.theCurrentRoom = new Room("a room");
        MySingleton.addRoom(MySingleton.theCurrentRoom); //Not using this yet...

        int openDoorIndex = Random.Range(0, 4);
        this.closedDoors[openDoorIndex].SetActive(false); //visually make an open door
        MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(openDoorIndex));

        for(int i = 0; i < 4; i++)
        {
            //if I am not looking at the already open door
            if(openDoorIndex != i)
            {
                //should this door be open or not?
                int coinFlip = Random.Range(0, 2);
                if(coinFlip == 1)
                {
                    //open the door in that direction
                    this.closedDoors[i].SetActive(false); //visually make an open door
                    MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(i));

                }
            }
        }
       
    }

    void Update()
    {
        
    }
}