﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {


	float h;
	float v;
	string currentAnim;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.A)) {
			animator.SetTrigger ("WalkLeft");
		
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			animator.SetTrigger ("WalkRight");

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetTrigger ("Attack");

		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			animator.SetTrigger ("Idle");

		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			animator.SetTrigger ("Idle");

		}

		/*
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		//print (h);

		if (currentAnim != "Idle" && h == 0 && v == 0) {
			// idle
			animator.SetTrigger("Idle");
			currentAnim = "Idle";
		}

		else if (currentAnim != "WalkLeft" && (h < 0)) {
			// left
			animator.SetTrigger("WalkLeft");
			currentAnim = "WalkLeft";
		}

		else if (currentAnim != "WalkRight" && (h > 0)) {
			//right
			animator.SetTrigger("WalkRight");
			currentAnim = "WalkRight";
		}
		*/

	}
}
