using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameControllerScript : MonoBehaviour {

    public bool debug;
    public KeyCode debugRegenParty;

    private GameObject[] party = new GameObject[4];
    private KeyCode[] dodgeKeys = new KeyCode[4] {KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R};
    private List<GameObject> backup;
    private List<GameObject> enemies;
    private EnemyScript currEnemy;
    private Vector3 heroPos = new Vector3(-6, 4.5f, 0);


    public HeroScript baseHero;

	void Start ()
    {
        GenerateParty();
	}

    void Update()
    {
        if(Input.GetKeyDown(debugRegenParty) && debug)
        {
            foreach(GameObject hero in party)
            {
                hero.GetComponent<HeroScript>().Death();
            }
            GenerateParty();
        }
    }

    private void GenerateParty()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject newHero = GenerateHero();
            party[i] = newHero;
            newHero.transform.position = heroPos - new Vector3(0, (i * 2.33f), 0);
            newHero.GetComponent<HeroScript>().dodgeKey = dodgeKeys[i];
            newHero.SetActive(true);
        }
    }

    private GameObject GenerateHero()
    {
        GameObject newHero = Instantiate(baseHero.gameObject) as GameObject;
        //newHero.Randomize();
        return newHero;
    }

    private void GenerateBackup()
    {
        GameObject newHero = GenerateHero();
        backup.Add(newHero);
        //animation
    }

    private void StartFight()
    {
        //animate heroes
        //open gui
    }

    public void NewRound()
    {
        for(int i = 0; i < 4; i++)
        {
           if(party[i] == null)
                ReplaceHero(i);
        }
        currEnemy.Attack();
    }

    public void RemoveHero(int partySlot)
    {
        party[partySlot] = null;
    }

    private void ReplaceHero(int partySlot)
    {
        if (backup.Count > 0)
        {
            party[partySlot] = backup[0];
            backup.RemoveAt(0);
            //animate party member running in
        }
        else
        {
            if(party[0] == null && party[1] == null && party[2] == null && party[3] == null)
            {
                GameOver();
            }
        }
    }

    private void EndFight()
    {
        enemies.RemoveAt(0);
        for(int i = 0; i < currEnemy.GetBackupReward(); i++)
        {
            GenerateBackup();
        }
        if(enemies.Count == 0)
        {
            //YOU WIN
        }
        else
        {
            currEnemy = enemies[0].GetComponent<EnemyScript>();
            StartFight();
        }
    }

    private void GameOver()
    {
        //Change to game over scene
    }
}
