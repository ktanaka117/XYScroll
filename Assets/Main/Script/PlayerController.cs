using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 movement = Vector3.zero;

		if (Input.GetKey (KeyCode.A) == true) {
		
			movement = new Vector3 (-movementSpeed, 0.0f, 0.0f);

		}

		if (Input.GetKey (KeyCode.D) == true) {

			movement = new Vector3 (movementSpeed, 0.0f, 0.0f);

		}

		transform.position += movement;

	}
}
