using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShiftRoom : MonoBehaviour {
	GameObject player;
	bool isTransitioning;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		isTransitioning = false;
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 viewPosition = this.GetComponent<Camera>().WorldToViewportPoint(player.transform.position);
		//print (viewPosition.y);

		if (!isTransitioning) {
			if (viewPosition.x > 0.99f) { // move right
				StartCoroutine(ScreenTransition(3.5f, 0));
			} else if (viewPosition.x < 0.01f) { // move left
				StartCoroutine(ScreenTransition(-3.5f, 0));

			} else if (viewPosition.y > 0.99f) { // move up
				StartCoroutine(ScreenTransition(0, 2));

			} else if (viewPosition.y < 0.01f) { // move down
				StartCoroutine(ScreenTransition(0, -2));
			}
		}
	}

	public IEnumerator ScreenTransition (float x, float y) {
		
		isTransitioning = true;

		Vector3 startPosition = transform.position;
		Vector3 targetPosition = new Vector3(transform.position.x + x, transform.position.y + y);


		while(Vector3.Distance(startPosition, targetPosition) > 0.005f)
		{
			startPosition = transform.position;
			transform.position = Vector3.MoveTowards(startPosition, targetPosition, 25.0f * Time.deltaTime);


			yield return null;
		}
		yield return new WaitForSeconds (1f);

		transform.position = targetPosition;
		isTransitioning = false;


	}
}
