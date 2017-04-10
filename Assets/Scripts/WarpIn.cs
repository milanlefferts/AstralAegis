using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpIn : MonoBehaviour {

	public GameObject WarpOut;

	void Start () {
		
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Shield") {
			other.gameObject.transform.parent.position = new Vector3 (WarpOut.transform.position.x, WarpOut.transform.position.y, other.gameObject.transform.parent.position.z);
		} else {
			other.gameObject.transform.position = new Vector3 (WarpOut.transform.position.x, WarpOut.transform.position.y, other.gameObject.transform.position.z);
		}
	}
}
