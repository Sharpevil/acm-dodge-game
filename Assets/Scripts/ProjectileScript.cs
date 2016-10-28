using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    public GameControllerScript controller;

	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0);
	}
	
	void Update () {
	    
	}
}
