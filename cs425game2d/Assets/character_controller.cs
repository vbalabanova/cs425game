using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour {

    public GameObject [] hearts;
    public GameObject losetext;
    public int health;
    public Animator animator;
    public Vector3[] positions = { new Vector3(-2, -1.88f, 0), new Vector3(0, -1.88f, 0), new Vector3(2, -1.88f, 0)};
    int index = 1;

	// Use this for initialization
	void Start () {
        health = 3;
        losetext.SetActive(false);
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

    private void changeHealth(int damage) {
        health += damage;
        switch (health)
        {
            case 1:
                for (int i = 0; i < hearts.Length; i++)
                {
                    if (i == 0)
                    {
                        hearts[i].SetActive(true);
                    }
                    else
                    {
                        hearts[i].SetActive(false);
                    }
                }
                break;
            case 2:
                for(int i = 0; i < hearts.Length; i++){
                    if (i == 2)
                    {
                        hearts[i].SetActive(false);
                    }
                    else {
                        hearts[i].SetActive(true);
                    }
                }
                break;
            case 3:
                foreach(GameObject g in hearts){
                    g.SetActive(true);
                }
                break;
            default:
                foreach (GameObject g in hearts)
                {
                    g.SetActive(false);
                }
                Debug.Log("YOU LOSE!!!!!!!!!!!!");
                losetext.SetActive(true);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Obstacle")
        {
            //lose health
            changeHealth(-1);
            Debug.Log("HIT\n");
            Destroy(collision.gameObject);
        }
    }
}
