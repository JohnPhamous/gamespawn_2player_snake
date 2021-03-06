﻿using System.Collections;
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
			SpriteRenderer renderer = other.GetComponent<SpriteRenderer>();
			renderer.color = new Color(1f, 0.0f, 0.0f, 1f);
			// Debug.Log(other.gameObject.GetComponent<Snake2>().move);
			other.gameObject.transform.position = other.gameObject.GetComponent<Snake2>().initial_position;
			other.gameObject.GetComponent<Snake2>().move = false;
		}
		if (other.gameObject.tag == "Player2") {
			SpriteRenderer renderer = other.GetComponent<SpriteRenderer>();
			renderer.color = new Color(1f, 0.0f, 0.0f, 1f);
			// Debug.Log(other.gameObject.GetComponent<Snake>().move);
			other.gameObject.transform.position = other.gameObject.GetComponent<Snake>().initial_position;
			other.gameObject.GetComponent<Snake>().move = false;
		}
	}
}
