using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] obstacles;
    public GameObject[] spawn_points;
    public float speed;
    public float time_bw_spawns;
    bool isPlaying = true;

	// Use this for initialization
	void Start () {
        speed = 3;
        time_bw_spawns = 2;
        StartCoroutine(ObstacleSpawning());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    IEnumerator ObstacleSpawning() {
        while (isPlaying)
        {
            int whichSpawn = Random.Range(0, 2);//exclusive so will either spawn 0 or 1
            if (whichSpawn == 0) {
                GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawn_points[Random.Range(0, spawn_points.Length)].transform.position, Quaternion.identity);
                obstacle.GetComponent<obstacle_movement>().SetSpeed(speed);
            }
            else if (whichSpawn == 1)
            {
                DoubleSpawn();
            }
            yield return new WaitForSeconds(time_bw_spawns);
        }
    }

    void DoubleSpawn()
    {
        int rand1 = Random.Range(0, spawn_points.Length);
        int rand2 = Random.Range(0, spawn_points.Length);
        while (rand1 == rand2) //making sure two things don't spawn in the same place
        {
            rand2 = Random.Range(0, spawn_points.Length);
        }
        GameObject obstacle1 = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawn_points[rand1].transform.position, Quaternion.identity);
        obstacle1.GetComponent<obstacle_movement>().SetSpeed(speed);
        GameObject obstacle2 = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawn_points[rand2].transform.position, Quaternion.identity);
        obstacle2.GetComponent<obstacle_movement>().SetSpeed(speed);
    }
}
