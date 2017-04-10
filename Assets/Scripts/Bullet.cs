using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 velocity;
	public Rigidbody2D rb2D;
	Vector3 dir;
	float speed;

	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
		velocity = rb2D.transform.up;
		speed = 1.0f;
		RayPew ();
	}
	void FixedUpdate() {
		//rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime * 0.5f);
		rb2D.AddForce (velocity * speed);

	}
	/*
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.name == "ShieldCollider") {

			rb2D.position = Vector2.Reflect (rb2D.position, Vector2.up);
		}
	}*/

	void RayPew () {
		//int mask = 1 << 8;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, 0.5f);
		if (hit.collider != null) {
			print (hit.collider.name);
			dir = Vector3.Reflect (((Vector3)hit.point - transform.position), hit.normal);
			//dir = Vector3.Reflect (transform.position, hit.normal);

		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.name == "PlayerCollider") {
			//print ("HHHIIIIT");
			//Vector2 dir = Vector2.Reflect (rb2D.position, Vector2.up);
			float angle = Mathf.Atan2 (-dir.x, dir.y) * Mathf.Rad2Deg;
			rb2D.rotation = angle;
			velocity = rb2D.transform.up;
			//rb2D.velocity = Vector3.zero;
			//rb2D.angularVelocity = 0.0f;
			//velocity = rb2D.transform.up;
			//transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

			//Destroy(this.gameObject);
			StartCoroutine(StartStop());
		}
				
	}

	IEnumerator StartStop () {
		velocity = Vector2.zero;

		yield return new WaitForSeconds (0.001f);
		velocity = rb2D.transform.up;
		speed = 1.5f;
	}


}
