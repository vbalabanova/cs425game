using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour {

    public Animator animator;
    public Vector3[] positions = { new Vector3(-2, -1.88f, 0), new Vector3(0, -1.88f, 0), new Vector3(2, -1.88f, 0)};
    int index = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            index--;
            if (index < 0)
            {
                index = 0;
            }
            //set player position
            this.transform.position = positions[index];
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            index++;
            if (index>2)
            {
                index = 2;
            }
            //set player position
            this.transform.position = positions[index];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("back_atck", true);
        }
        else
        {
            animator.SetBool("back_atck", false);
        }
    }
}
