using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor, southDoor, eastDoor, westDoor;
    public GameObject northPowerPellet, eastPowerPellet, southPowerPellet, westPowerPellet;

    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if(theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
            this.northPowerPellet.SetActive(true);            
        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
            this.southPowerPellet.SetActive(true); 
        }

        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
            this.eastPowerPellet.SetActive(true); 
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
            this.westPowerPellet.SetActive(true); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}