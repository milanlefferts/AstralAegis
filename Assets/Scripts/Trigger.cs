using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	ScreenShake screenshaker;

	public GameObject obj;
	void Start () {
		screenshaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Shield") {
			this.GetComponent<BoxCollider2D> ().enabled = false;
			StartCoroutine (screenshaker.ScreenShaker (0.05f, 3f));
			StartCoroutine (MoveObject (obj));
		}
	}

	public IEnumerator MoveObject (GameObject obj) {


		Vector3 startPosition = obj.transform.position;
		Vector3 targetPosition = new Vector3(obj.transform.position.x, obj.transform.position.y + 2);


		while(Vector3.Distance(startPosition, targetPosition) > 0.005f)
		{
			print (1);
			startPosition = obj.transform.position;
			obj.transform.position = Vector3.MoveTowards(startPosition, targetPosition, 0.5f * Time.deltaTime);
			yield return null;
		}
		yield return new WaitForSeconds (2f);

		obj.transform.position = targetPosition;


	}
}
