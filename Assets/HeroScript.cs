using UnityEngine;
using System.Collections;
using System;

public class HeroScript : MonoBehaviour {

    public GameControllerScript controller;
    public float invulnCooldown;
    public float invulnTime;

    private string heroName;
    private KeyCode dodgeKey;
    private int partyPos;
    private bool invuln;
    private bool canInvuln;

	void Start () {
	
	}
	
	void Update () {
	    if(Input.GetKeyDown(dodgeKey) && canInvuln)
        {
            //Dodge animation
            StartCoroutine(Dodge());
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hurt")
        {
            Death();
        }
    }

    private void Death()
    {
        //Death animation
        controller.RemoveHero(partyPos);
    }

    void Randomize()
    {
        //randomize hero's sprite
    }

    // Sets the character invulnerable for the invuln period, then allows another dodge after the cooldown period.
    IEnumerator Dodge()
    {
        invuln = true;
        canInvuln = false;
        yield return new WaitForSeconds(invulnTime);
        invuln = false;
        yield return new WaitForSeconds(invulnCooldown);
        canInvuln = true;
    }
}
