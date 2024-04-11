using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class ShopController : MonoBehaviour
{
    public TextMeshPro playerTMP, itemTMP, shop_actions_TMP, shop_info_TMP;

    // Start is called before the first frame update
    void Start()
    {
        this.updatePlayerTMP();
        this.itemTMP.text = "Item cost: " + ItemsSingleton.cherryItemCost;
    }

    private void updatePlayerTMP()
    {
        this.playerTMP.text = "Pellets: " + MySingleton.currentPellets + "(HP: " + MySingleton.thePlayer.getHP() + ")"; ;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            //charge the player for the item
            if(MySingleton.currentPellets >= ItemsSingleton.cherryItemCost)
            {
                MySingleton.currentPellets -= ItemsSingleton.cherryItemCost;
                MySingleton.thePlayer.addHP(5);
                this.updatePlayerTMP();
            }
        }
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            EditorSceneManager.LoadScene("FightRoom");
        }
       
    }
}