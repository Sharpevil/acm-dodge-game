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
 //       newHero.Randomize();
        return newHero;
    }

    private void StartFight()
    {
        //animate heroes
        //open gui
    }

    private void NewRound()
    {
        for(int i = 0; i < 4; i++)
        {
           if(party[i] == null)
                ReplaceHero(i);
        }

    }

    private void ReplaceHero(int partySlot)
    {
        throw new NotImplementedException();
    }
}
