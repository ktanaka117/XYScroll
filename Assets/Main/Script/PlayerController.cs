using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public GameObject childPrefab;

	public float movementSpeed = 0.1f;
	public float rotateSpeed;

	public Camera playerCamera;

	public int score;
	public Text scoreText;

	bool isOriginal = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 movement = Vector3.zero;

		if (Input.GetKey (KeyCode.W) == true) {
			transform.position += transform.forward * movementSpeed;
		}

		if (Input.GetKey (KeyCode.S) == true) {
			transform.position -= transform.forward * movementSpeed;
		}

		if (Input.GetKey (KeyCode.A) == true) {
			transform.Rotate (Vector3.up, -rotateSpeed);
		}

		if (Input.GetKey (KeyCode.D) == true) {
			transform.Rotate (Vector3.up, rotateSpeed);
		}

//		if (Input.GetKey (KeyCode.A) == true) {
//			movement = new Vector3 (-movementSpeed, 0.0f, 0.0f);
//		}
//
//		if (Input.GetKey (KeyCode.D) == true) {
//			movement = new Vector3 (movementSpeed, 0.0f, 0.0f);
//		}
//
//		transform.position += movement;

	}

	void FixedUpdate() {
//		if (Input.GetMouseButtonDown (0)) {
//			GameObject cubePrefab = Instantiate (cube, transform.position + transform.forward*2f, transform.localRotation) as GameObject;
//			print (transform.forward);
//			cubePrefab.GetComponent<Rigidbody> ().AddForce (transform.position + transform.forward*100f , ForceMode.Impulse);
//		}
			if (transform.localScale.x / 2 > 1.0f) {
			if (Input.GetKeyDown (KeyCode.Space) == true) {
				GameObject child = Instantiate (childPrefab, transform.position + transform.forward*2f, transform.localRotation) as GameObject;
				child.GetComponent<Rigidbody> ().AddForce (transform.position + transform.forward*100f , ForceMode.Impulse);

				toHalfScale(child);
				toHalfScale (this.gameObject);

				fireChild (child);

				child.GetComponent<PlayerController> ().isOriginal = false;

				deleteCamera (child);
			}
		}
	}
		
	void fireChild(GameObject child) {
		// TODO: 射出する
		// キーワードは「どの向きに」「何が」「どのくらいの力で」、慣性
	}

	void toHalfScale(GameObject obj) {
		obj.transform.localScale /= 2;
	}

	void deleteCamera(GameObject obj) {
		Camera camera = obj.transform.GetComponentInChildren<Camera> ();
		if (camera != null) {
			Destroy (camera.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		transform.localScale += other.transform.localScale;

		score++;
		scoreText.text = "Score: " + score;

		Destroy (other.gameObject);
	}

}
