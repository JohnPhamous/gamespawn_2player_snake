using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake2 : MonoBehaviour {

	Vector2 dir = Vector2.right;
	List<Transform> tail = new List<Transform>();
	bool ate = false;
	public GameObject tailPrefab;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Move", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.D)) {
			if (dir == Vector2.left) {
				return;
			}
			dir = Vector2.right;
		}
		else if (Input.GetKey(KeyCode.S)) {
			if (dir == Vector2.up) {
				return;
			}
			dir = -Vector2.up;
		}
		else if (Input.GetKey(KeyCode.A)) {
			if (dir == Vector2.right) {
				return;
			}
			dir = -Vector2.right;
		}
		else if (Input.GetKey(KeyCode.W)) {
			if (dir == -Vector2.up) {
				return;
			}
			dir = Vector2.up;
		}
	}
	/*
	The head changes position. Creates a new tail object
	where the head was. Deletes the last tail object.
	 */
	void Move() {
		// saves current position 
		Vector2 v = transform.position;
		// GetComponent<Rigidbody2D>().MovePosition(dir);
		// Move head in new direction based on input
		transform.Translate(dir);

		if (ate) {
			GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
			tail.Insert(0, g.transform);
			ate = false;
		}
		else if (tail.Count > 0) {
			// Moves last tail object to where head was
			tail.Last().position = v;
			// adds a tail object to the front of the list
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count - 1);
		}
	}
	void onTriggerEnter2D(Collider2D coll) {
		if (coll.name.StartsWith("FoodPrefab")) {
			ate = true;
			Destroy(coll.gameObject);
		}
	}
}
