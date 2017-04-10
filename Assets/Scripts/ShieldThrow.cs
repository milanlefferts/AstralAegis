using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour {
	Rigidbody2D rb;
	public Animator animator;
	public Vector2 velocity;
	float speed;
	public float duration;
	public Player player;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator> ();
		velocity = rb.transform.up;
		speed = 2.5f;
		duration = 1f;
		player.shieldIsSpawned = true;

		StartCoroutine (Implode ());
	}
	
	void FixedUpdate() {
		rb.AddForce (velocity * speed);
	}
		
	void OnDisable () {
		player.shieldIsSpawned = false;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.name != "ShieldCollider" && collision.collider.name != "PlayerCollider") {
			StartCoroutine (ShieldExplosion ());
		}
	}

	public IEnumerator ShieldExplosion() {
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;

		animator.SetTrigger ("ShieldExplode");

		yield return new WaitForSeconds (0.2f);

		Destroy(this.gameObject);

	}

	public IEnumerator Implode() {
		while (duration > 0) {
			yield return new WaitForSeconds (0.5f);
			duration -= 0.5f;
		}
		StartCoroutine (ShieldExplosion ());
	}
}
