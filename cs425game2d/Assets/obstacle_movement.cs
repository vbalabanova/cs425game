using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_movement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(0.0f, (-1 * speed));
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void SetSpeed(float speed) {
        this.speed = speed;
    }
}
