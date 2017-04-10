using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public Vector2 velocity;
	public Rigidbody2D rb2D;
	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
		velocity = transform.right;
	}
	void FixedUpdate() {
		rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime * 0.5f);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		print (coll.gameObject.name);
		if (coll.collider.name == "ShieldCollider") {
			print ("SHIELD");
			// block / deflect
		}

		if (coll.collider.name == "PlayerCollider") {
			print ("PLAYER");
			// damage player
		}

	}
}
