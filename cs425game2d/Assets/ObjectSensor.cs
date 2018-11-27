using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSensor : MonoBehaviour {

    public MoleBehaviour mb;//reference to the mole script
    public bool incomingObject;

	// Use this for initialization
	void Start () {
        incomingObject = false;
        mb = GameObject.FindGameObjectWithTag("Enemy").GetComponent<MoleBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //checks if one of the obstacles hit the hitbox
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            incomingObject = true;
            mb.startMove = true;
        }
    }
}
