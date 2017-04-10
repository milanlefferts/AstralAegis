using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public GameObject Reaction;
	private bool activated;
	public string switchElement;

	private Player player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		switchElement = "Neutral";
		activated = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Shield" || other.tag == "Player") {
			if (switchElement == player.element) {
				ActivateSwitch ();
				Reaction.GetComponent<Reaction> ().React ();
			}
		
		}
	}

	void ActivateSwitch () {
		activated = true;
		// switch color to ACTIVE
	}
}
