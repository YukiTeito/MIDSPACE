﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	public float dx;
	public float dy;
	public Boolean start = false;
	public void bulletData(double angels) {
		dx = (float) (0.05 * Math.Cos(angels));
		dy = (float) (0.05 * Math.Sin(angels));
		start = true;
	}
	// Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update () {
	    if(start) transform.Translate(dx, dy, 0);

	    if (transform.position.y < -5 || transform.position.y > 5
	        || transform.position.x > 6.5 || transform.position.x < -6.5) { 
		    Destroy (gameObject);
	    } 
    }
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("Player")) {
			CpControl.HitPoint.hitPoint -= 1;
			Destroy(gameObject);
		}
	}
}