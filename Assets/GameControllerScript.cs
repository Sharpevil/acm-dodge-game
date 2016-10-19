using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameControllerScript : MonoBehaviour {

    private GameObject[] party = new GameObject[4];
    private List<GameObject> backup;
    private List<GameObject> enemies;
    private EnemyScript currEnemy;

    public HeroScript baseHero;

	void Start ()
    {
        GenerateParty();
	}

    void Update()
    {

    }

    private void GenerateParty()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject newHero = GenerateHero();
            party[i] = newHero;
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
        throw new NotImplementedException();
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
