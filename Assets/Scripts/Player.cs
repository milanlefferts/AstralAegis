using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject shieldProjectile;

	float h;
	float v;
	string currentAnim;

	Animator animator;
	Rigidbody2D rb;

	BoxCollider2D shieldCollider;
	BoxCollider2D playerCollider;
	GameObject shieldThrowSpan;
	public GameObject shield;

	// Player health
	int health;

	public string element;

	// Move player
	private float moveSpeed = 1f; // movement speed

	// Blocking
	public bool isBlocking;
	int mass;

	// Attacking
	public bool shieldIsSpawned;

	void Start () {

		animator = GetComponentInChildren<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		shieldCollider = transform.Find ("ShieldCollider").GetComponent<BoxCollider2D> ();
		shieldCollider.enabled = false;
		playerCollider = transform.Find ("PlayerCollider").GetComponent<BoxCollider2D> ();
		shieldThrowSpan = transform.Find ("ShieldThrowSpawn").gameObject;
		mass = 10;
		rb.mass = mass;
		health = 2;


		isBlocking = false;

		element = "Neutral";
	
	
	}

	void FixedUpdate () {
		// Walking (rigidbody)
		Vector2 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		rb.velocity = move * moveSpeed;
		//rb.AddForce ((move * moveSpeed), ForceMode2D.Impulse);
	}
	
	void Update () {

		if (Input.GetKeyDown (KeyCode.E) && !shieldIsSpawned) {
			shield = Instantiate (shieldProjectile, shieldThrowSpan.transform.position, this.transform.rotation);

		} 

		if (Input.GetKeyDown (KeyCode.E) && shieldIsSpawned) {

			shield.GetComponent<ShieldThrow>().animator.SetTrigger ("ShieldExplode");


			StartCoroutine (shield.GetComponent<ShieldThrow>().ShieldExplosion ());

			this.transform.position = shield.transform.position;

		}


		if (!isBlocking) {

			// Walking (translate)
			//Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			//transform.position += move * moveSpeed * Time.deltaTime;

			/*
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");


			if (h == 0 && v == 0) {
				animator.SetTrigger ("Idle");
			}
			else if (v > 0) {
				animator.SetTrigger ("Up");
			} else if (v < 0) {
				animator.SetTrigger ("Down");
			} else if (h < 0) {
				animator.SetTrigger ("Left");
			} else if (h > 0) {
				animator.SetTrigger ("Right");
			} 
*/
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");


			if (Input.GetKeyDown (KeyCode.W)) {
				animator.SetTrigger ("Up");
				transform.eulerAngles = new Vector3 (0f, 0f, 0f);
			} 

			else if (Input.GetKeyDown (KeyCode.S)) {
				transform.eulerAngles = new Vector3 (0f, 0f, 180f);
				//animator.SetTrigger ("Down");
				animator.SetTrigger ("Up");

			} 

			else if (Input.GetKeyDown (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (0f, 0f, 90f);
				//animator.SetTrigger ("Left");
				animator.SetTrigger ("Up");

			} 
			else if (Input.GetKeyDown (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (0f, 0f, -90f);
				//animator.SetTrigger ("Right");
				animator.SetTrigger ("Up");

			} else if (h == 0 && v == 0) {
				animator.SetTrigger ("Idle");
			}

		}


		// Blocking
		if (Input.GetKeyDown (KeyCode.Space)) {
			//print ("shield plz");
			isBlocking = true;
			shieldCollider.enabled = true;
			rb.mass = mass * 8.0f;

			animator.SetTrigger ("Shield");
		} 

		if (Input.GetKeyUp (KeyCode.Space)) {
			if (isBlocking) {
				isBlocking = false;
				shieldCollider.enabled = false;
				rb.mass = mass;

				//animator.SetTrigger ("Idle");
				//print ("shield gone");
			}
		}


	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Enemy") {

		}
		//print ("collide!");
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name == "Void") {
			print ("You fall down");
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
