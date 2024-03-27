using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP, fight_information_TMP, player_turn_TMP;
    private int heroHP;
    private int monsterHP;
    private int heroArmorClass;
    private int monsterArmorClass;
    private int heroAttack;
    private int monsterAttack;
    private int heroDamage;
    private int monsterDamage;
    private bool heroTurn;
    private bool monsterTurn;
    private float speed = 2.0f;
    public GameObject attackPosition, heroStartPosition, monsterStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.heroHP = 30;
        this.monsterHP = 30;
        this.heroArmorClass = 12;
        this.monsterArmorClass = 14;
        this.hero_hp_TMP.text = "Hero HP: " + this.heroHP;
        this.monster_hp_TMP.text = "Monster HP: " + this.monsterHP;
        this.monsterTurn = false;
        this.heroTurn = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.UpArrow) && heroTurn.Equals(true))
        {
            this.heroAttack = (int)Random.Range(1.0f, 20.0f);
            if(this.heroAttack > this.monsterArmorClass)
            {
                //this.fight_information_TMP.text = "Hero Attack Hit!";
                this.heroDamage = (int)Random.Range(1.0f, 20.0f);
                this.monsterHP = this.monsterHP - this.heroDamage;
                this.monster_hp_TMP.text = "Monster HP: " + this.monsterHP;
                this.heroTurn = false;
                this.monsterTurn = true; 
                //this.player_turn_TMP.text = "Monster Turn";
            }
            else
            {
                //this.fight_information_TMP.text = "Hero Attack Miss!";
                this.heroTurn = false;
                this.monsterTurn = true;
                //this.player_turn_TMP.text = "Monster Turn";
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && monsterTurn.Equals(true))
        {
            this.monsterAttack = (int)Random.Range(1.0f, 20.0f);
            if(this.monsterAttack > this.heroArmorClass)
            {
                //this.fight_information_TMP.text = "Monster Attack Hit!";
                this.monsterDamage = (int)Random.Range(1.0f, 20.0f);
                this.heroHP = this.heroHP - this.monsterDamage;
                this.hero_hp_TMP.text = "Hero HP: " + this.heroHP;
                this.monsterTurn = false;
                this.heroTurn = true; 
                //this.player_turn_TMP.text = "Hero Turn";
            }
            else
            {
                //this.fight_information_TMP.text = "Monster Attack Miss!";
                this.monsterTurn = false;
                this.heroTurn = true;
                //this.player_turn_TMP.text = "Hero Turn";
            }

        }
        if(this.monsterHP <= 0)
        {
            this.monster_hp_TMP.text = "Monster HP: 0";
            this.fight_information_TMP.text = "Hero Wins!";
        }
        if(this.heroHP <= 0)
        {
            this.hero_hp_TMP.text = "Hero HP: 0";
            this.fight_information_TMP.text = "Monster Wins";
        }        
    }
}