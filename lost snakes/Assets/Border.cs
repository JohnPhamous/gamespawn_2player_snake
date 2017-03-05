using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log("Hit");
			Debug.Log("Snake");
			other.gameObject.transform.position = other.gameObject.GetComponent<Snake2>().initial_position;
		}
		if (other.gameObject.tag == "Player2") {
			Debug.Log("Hit");
			Debug.Log("Snake2");
			other.gameObject.transform.position = other.gameObject.GetComponent<Snake>().initial_position;
			
		}
	}
}
