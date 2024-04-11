using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;


public class fightController : MonoBehaviour
{
    private bool isFightOver = false;
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP, fight_information_TMP;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    public Monster theMonster;
    private bool shouldAttack = true;
    

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Blue Ghost");
        this.hero_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();
        this.monster_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();

        int num = Random.Range(0, 2); //coin flip, will produce 0 and 1 (since 2 is not included)
        if(num == 0)
        {
            this.currentAttacker = hero_GO;
        }
        else
        {
            this.currentAttacker = monster_GO;
        }
        this.fight_information_TMP.text = "Press the up arrow to begin the fight. Press the down arrow to visit the shop.";
        
    }

    private void tryAttack(Inhabitant attacker, Inhabitant defender)
    {
        this.fight_information_TMP.text = "";
        //have attacker try to attack the defender
        int attackRoll = Random.Range(0, 20)+1;
        if(attackRoll >= defender.getAC())
        {
            //attacker will hit the defender, lets see how hard!!!!            
            int damageRoll = Random.Range(0, 4) + 2; //damage between 2 and 5
            defender.takeDamage(damageRoll);
            this.fight_information_TMP.text = "Attacker Hit!!!!";
            
        }
        else
        {
            this.fight_information_TMP.text = "Attacker Misses!!!!";
        }
    }

    IEnumerator fight()
    {
        yield return new WaitForSeconds(2);
        if (this.shouldAttack)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
            this.theCurrentAnimator.SetTrigger("attack");
            if (this.currentAttacker == this.hero_GO)
            {
                this.currentAttacker = this.monster_GO;
                this.tryAttack(MySingleton.thePlayer, this.theMonster);
                this.monster_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();

                //now the defender may have fewer hp...check if their are dead?
                if (this.theMonster.getHP() <= 0)
                {
                    this.fight_information_TMP.text = "Hero Wins! Press Space to return to the dungeon.";
                    this.shouldAttack = false;
                    this.isFightOver = true;
                    MySingleton.currentPellets++;
                }    
                else
                {
                    StartCoroutine(fight());
                }
                
            }
            else
            {
                this.currentAttacker = this.hero_GO;
                this.tryAttack(this.theMonster, MySingleton.thePlayer);
                this.hero_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();

                //now the defender may have fewer hp...check if their are dead?
                if (MySingleton.thePlayer.getHP() <= 0)
                {
                    this.fight_information_TMP.text = "Monster Wins! Press Space to return to the dungeon.";
                    this.shouldAttack = false;
                    this.isFightOver = true;
                }
                else
                {
                    StartCoroutine(fight());
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            StartCoroutine(fight());
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            EditorSceneManager.LoadScene("ShopKeeperScene");
        }

        if(isFightOver = true && Input.GetKeyUp(KeyCode.Space))
        {
            MySingleton.thePlayer.resetStats();
            EditorSceneManager.LoadScene("Dungeon");
        }
    }
}