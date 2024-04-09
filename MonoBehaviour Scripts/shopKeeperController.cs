using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class shopKeeperController : MonoBehaviour
{
    
    public TextMeshPro item_cost_TMP, shop_info_TMP, shop_actions_TMP;
    
    // Start is called before the first frame update
    void Start()
    {
        this.item_cost_TMP.text = "Cost: 2 pellets";
        if(MySingleton.currentPellets >=2)
        {
            this.shop_info_TMP.text = "You have enough pellets to purchase this item. Proceed?";
            this.shop_actions_TMP.text = "Press Y to purchase item. Press Space to return to dungeon.";
            if(Input.GetKeyUp(KeyCode.Y))
            {
                this.shop_info_TMP.text = "Thank you for your purchase.";
                MySingleton.hasItem = true;
            }

        }
        else
        {
            this.shop_info_TMP.text = "You do not have enough pellets to purchase this item. Return to the dungeon to collect more.";
            this.shop_actions_TMP.text = "Press Space to return to dungeon.";
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            EditorSceneManager.LoadScene("FightRoom");
        }
    }
}
