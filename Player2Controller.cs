using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro playerInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        this.thePlayer = new Player("Dave");
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
        
    }
}
