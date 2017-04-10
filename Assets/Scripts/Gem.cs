using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
	Player player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Shield") {
			player.shield.GetComponent<ShieldThrow> ().duration += 0.5f;
			StartCoroutine (StartRespawnCounter());
		}
	}

	IEnumerator StartRespawnCounter () {
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;

		yield return new WaitForSeconds (5f);
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		this.gameObject.GetComponent<BoxCollider2D> ().enabled = true;

	}
}
