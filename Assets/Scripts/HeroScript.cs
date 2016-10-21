using UnityEngine;
using System.Collections;
using System;

public class HeroScript : MonoBehaviour {

    public GameControllerScript controller;
    public float invulnCooldown;
    public float invulnTime;
    public KeyCode dodgeKey;

    private Animator anim;
    private string heroName;
    private int partyPos;
    private bool invuln;
    private bool canInvuln = true;

	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	void Update () {
	    if(Input.GetKeyDown(dodgeKey) && canInvuln)
        {
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
        anim.SetBool("Dodge", true);
        yield return new WaitForSeconds(invulnTime);
        invuln = false;
        anim.SetBool("Dodge", false);
        yield return new WaitForSeconds(invulnCooldown);
        canInvuln = true;
    }
}
