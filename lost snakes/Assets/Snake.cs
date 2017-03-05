using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour {
	Vector3 dir = Vector3.right;
	public Vector3 initial_position;
	List<Transform> tail = new List<Transform>();
	public bool ate = false;
	public GameObject tailPrefab;
	public bool move = true;
	
	// move sound effect
	public AudioClip move_sound;
	private AudioSource audio_source;

	// Use this for initialization
	void Start () {
		initial_position = new Vector3();
		initial_position = transform.position;
		InvokeRepeating("Move", 0.1f, 0.1f);
		audio_source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x % 1.0 == 0.0 || transform.position.y % 1.0 == 0.0) {
			if (Input.GetKey(KeyCode.D)) {
				if (dir == Vector3.left) {
					return;
				}
				dir = Vector3.right;
			}
			else if (Input.GetKey(KeyCode.S)) {
				if (dir == Vector3.up) {
					return;
				}
				dir = -Vector3.up;
			}
			else if (Input.GetKey(KeyCode.A)) {
				if (dir == Vector3.right) {
					return;
				}
				dir = -Vector3.right;
			}
			else if (Input.GetKey(KeyCode.W)) {
				if (dir == -Vector3.up) {
					return;
				}
				dir = Vector3.up;
			}
		}
	}
	
	/*
	The head changes position. Creates a new tail object
	where the head was. Deletes the last tail object.
	 */
	void Move() {
		if (move) {
			audio_source.PlayOneShot(move_sound, 2F);
			// saves current position 
			Vector3 v = transform.position;

			// Move head in new direction based on input
			GetComponent<Rigidbody2D>().MovePosition(transform.position + dir);
			
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
		else {
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			renderer.color = new Color(1f, 0.0f, 0.0f, 1f);
			Invoke("stun", 1);
		}
	}
	void stun() {
		move = true;
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		// changes sprite to red when collision is detected
		renderer.color = new Color(1f, 1f, 1f, 1f);
	}
}
