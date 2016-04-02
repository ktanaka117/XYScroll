using UnityEngine;
using System.Collections;

public class ItemGenerater : MonoBehaviour {

	public GameObject itemPrefab;
	public float waitForSeconds;
	public float radius;

	void Start() {
		StartCoroutine (GenerateItemEveryTime ());
	}

	void Update() {

	}

	// アイテムを生成するメソッド
	private void GenerateItem() {
		Vector2 randomPosition = Random.insideUnitCircle * radius;
		Vector3 itemPosition = 
			new Vector3 (
				randomPosition.x,
				0.0f,
				randomPosition.y);

		GameObject itemInstance = Instantiate (itemPrefab);
		Vector3 tempPosition = itemInstance.transform.position;
		tempPosition.x = itemPosition.x;
		tempPosition.z = itemPosition.y;

		itemInstance.transform.position = tempPosition;
	}

	// アイテムを一定間隔え生成するメソッド
	IEnumerator GenerateItemEveryTime() {
		while (true) {
			GenerateItem ();

			yield return new WaitForSeconds (waitForSeconds);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (1.0f, 0.0f, 0.0f, 0.5f);
		Gizmos.DrawSphere (transform.position, radius);
	}

}
