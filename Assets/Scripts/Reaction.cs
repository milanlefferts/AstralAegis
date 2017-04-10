using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour {

	public int required;
	private bool reacted;
	public string switchElement;

	private Player player;
	private Rigidbody2D rb;

	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		reacted = false;
	}



	public void React () {
		reacted = true;
		// switch color to ACTIVE
		//rb.SetActive(false);
	}
}
