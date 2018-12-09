using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour {

    public GameController gc;
    public GameObject arrow;
    public float animtime;
    public bool isCollecting;
    public GameObject [] hearts;
    public GameObject losetext;
    public int health;
    public Animator animator;
    public Vector3[] positions = { new Vector3(-2, -1.88f, 0), new Vector3(0, -1.88f, 0), new Vector3(2, -1.88f, 0)};
    int index = 1;

    public bool collectedRock;
    public bool collectedLeaf;
    public bool collectedWood;

    public GameObject rockCheck;
    public GameObject leafCheck;
    public GameObject woodCheck;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        rockCheck.SetActive(false);
        woodCheck.SetActive(false);
        leafCheck.SetActive(false);

        collectedLeaf = false;
        collectedRock = false;
        collectedWood = false;
        isCollecting = false;
        health = 3;
        losetext.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow) && gc.isPlaying)
        {
            index--;
            if (index < 0)
            {
                index = 0;
            }
            //set player position
            this.transform.position = positions[index];
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && gc.isPlaying)
        {
            index++;
            if (index>2)
            {
                index = 2;
            }
            //set player position
            this.transform.position = positions[index];
        }
        //attack down
        if (Input.GetKeyDown(KeyCode.DownArrow) && collectedLeaf && collectedRock && collectedWood && gc.isPlaying)
        {
            animator.SetBool("back_atck", true);
            rockCheck.SetActive(false);
            leafCheck.SetActive(false);
            woodCheck.SetActive(false);
            collectedLeaf = false;
            collectedRock = false;
            collectedWood = false;
            Instantiate(arrow, this.gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            animator.SetBool("back_atck", false);
        }
        //attack up
        if (Input.GetKeyDown(KeyCode.UpArrow) && gc.isPlaying)
        {
            animator.SetBool("front_atck", true);
            StartCoroutine(Collect());
        }
        else
        {
            animator.SetBool("front_atck", false);
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
                gc.isPlaying = false;
                Time.timeScale = 0;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && !isCollecting)
        {
            //lose health
            changeHealth(-1);
            Debug.Log("HIT\n");
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Obstacle" && isCollecting)
        {
            if (collision.gameObject.name == "rock(Clone)") {
                collectedRock = true;
                rockCheck.SetActive(true);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "sign(Clone)" || collision.name == "trunk(Clone)")
            {
                collectedWood = true;
                woodCheck.SetActive(true);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "bush(Clone)")
            {
                collectedLeaf = true;
                leafCheck.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
    }

    IEnumerator Collect()
    {
        isCollecting = true;
        yield return new WaitForSeconds(animtime);
        isCollecting = false;
    } 
}
