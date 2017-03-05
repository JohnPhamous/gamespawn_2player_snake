using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Properties : MonoBehaviour {
	// Border locations
	private SpawnFood counter_getter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D snake) {
		counter_getter = gameObject.GetComponent<SpawnFood>();
		float bottom_bound = GameObject.Find("border_bottom").transform.position.y;
		float top_bound = GameObject.Find("border_top").transform.position.y;
		float left_bound = GameObject.Find("border_left").transform.position.x;
		float right_bound = GameObject.Find("border_right").transform.position.x;
		int x = (int)Random.Range(left_bound + 2, right_bound - 2);
		int y = (int)Random.Range(top_bound - 2, bottom_bound + 2);
		Vector3 delta_position = new Vector3(x, y, 0);
		
		if (snake.gameObject.tag == "Player2") {
            snake.gameObject.GetComponent<Snake>().ate = true;
            // Destroy(gameObject);
			gameObject.transform.position = delta_position;
        }
		if (snake.gameObject.tag == "Player") {
            snake.gameObject.GetComponent<Snake2>().ate = true;
            // Destroy(gameObject);
			gameObject.transform.position = delta_position;
        }
		// Debug.Log("Inside Food_Prop(): " + counter_getter.counter);
    }
}
