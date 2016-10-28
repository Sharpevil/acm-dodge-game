using UnityEngine;
using System.Collections;
using System;

public class HeroScript : MonoBehaviour {

    public GameControllerScript controller;
    public float invulnCooldown;
    public float invulnTime;
    public KeyCode dodgeKey;

    private Rigidbody2D rb2d;
    private Animator anim;
    private string heroName;
    private float destroyDelay = 3f;
    private int partyPos;
    private bool invuln;
    private bool canInvuln = true;

	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	void Update () {
	    if(Input.GetKeyDown(dodgeKey) && canInvuln)
        {
            StartCoroutine(Dodge());
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        print("yahoo");
        if (col.gameObject.tag == "Hurt")
        {
            Death();
        }
    }

    public void Death()
    {
        rb2d.gravityScale = 2f;
        rb2d.AddForce(new Vector2(-10, 150));
        rb2d.AddTorque(UnityEngine.Random.Range(-30f, 30f));
        controller.RemoveHero(partyPos);
        Destroy(gameObject, destroyDelay);
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
