using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class Player1Controller : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro playerInfo;
    public GameObject destinationGO;
    public float speed = 0;
    public GameObject EntryGO;


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

    private void OnTriggerEnter(Collider other)
    {
        EditorSceneManager.LoadScene("Scene2");
       
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, 
                                                    this.destinationGO.transform.position, speed);
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, 
                                                    this.EntryGO.transform.position, speed);
    }
}



