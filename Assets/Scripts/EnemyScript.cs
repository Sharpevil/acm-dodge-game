using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameControllerScript controller;
    public int[] attacks;
    public string enemyName;
    public int mana;
    public int backupReward = 0;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public int GetBackupReward()
    {
        return backupReward;
    }

    public void Attack()
    {
        System.Random rand = new System.Random();
        int attack = attacks[rand.Next(0, attacks.Length + 1)];
        switch (attack)
        {
            case 1:
                //Attack 1, etc
                break;
            default:
                break;
        }
    }

    private IEnumerator EndAttack(int attackLength)
    {
        yield return new WaitForSeconds(attackLength);
        if (mana > 0)
        {
            controller.NewRound();
        }
        else
        {
            //gui pop up
        }
    }
}
