using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro playerInfo;
    public GameObject destinationGO;
    public float speed = 0;


    // Start is called before the first frame update
    void Start()
    {
        this.thePlayer = new Player("Mike");  
        this.thePlayer.display();
        SetPlayerInfo();
    }


    void SetPlayerInfo()
    {
        playerInfo.text = this.thePlayer.getName() + " -> " + this.thePlayer.getHP();

    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, 
                                                    this.destinationGO.transform.position, speed);
               
    }
}



