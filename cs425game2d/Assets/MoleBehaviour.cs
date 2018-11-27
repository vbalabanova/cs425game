using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehaviour : MonoBehaviour {

    public Vector3[] positions = { new Vector3(-2, -0, 0), new Vector3(0, -0, 0), new Vector3(2, -0, 0) };
    public GameObject[] sensors;
    public bool startMove;
    public float molespeed;

    // Use this for initialization
    void Start () {
        startMove = false;
        molespeed = 2;
	}
	
	// Update is called once per frame
	void Update () {
        if (startMove)
        {
            this.makeMove();
        }
	}

    void makeMove()
    {
        int[] indexes = { -1, -1 };
        for (int i = 0; i < sensors.Length; i++) {//loops through sensors
            if (sensors[i].GetComponent<ObjectSensor>().incomingObject == false)//checking the sensors for safe positions
            {
                //the next code handles the case when there are two safe positions
                if (indexes[0] == -1)//copies first safe index
                {
                    indexes[0] = i;
                }
                else {//if a safe location was already saved and you need to save another
                    indexes[1] = i;
                }
            }
        }

        //now have the safe indexes so need to pick one if there are multiple
        if (indexes[1] != -1)
        {
            int newPos = Random.Range(0, 2);
            try
            {
                StartCoroutine(Move_Routine(this.transform, this.transform.position, positions[indexes[newPos]]));
                //this.transform.position = positions[indexes[Random.Range(0, 2)]];

                //this.transform.position = Vector3.Lerp(this.transform.position, positions[indexes[Random.Range(0, 2)]], Time.deltaTime);
            }
            catch (System.IndexOutOfRangeException e){
                Debug.Log("EXCEPTION ON POS:" + newPos + "indexes[newPos]" + indexes[newPos]);
            }
        }
        else if(indexes[0] != -1){
            int newPos2 = indexes[0];
            try
            {
                StartCoroutine(Move_Routine(this.transform, this.transform.position, positions[newPos2]));
                //this.transform.position = positions[indexes[0]];

                //this.transform.position = Vector3.Lerp(this.transform.position, positions[indexes[0]], Time.deltaTime);
            }
            catch (System.IndexOutOfRangeException e)
            {
                Debug.Log("EXCEPTION ON POS2:" + newPos2);
            }
        }

        this.resetSensors();
        indexes[0] = -1;
        indexes[1] = -1;
        startMove = false;
    }

    //function to reset the sensors after the mole dodges
    void resetSensors()
    {
        for (int i = 0; i < sensors.Length; i++)
        {
            sensors[i].GetComponent<ObjectSensor>().incomingObject = false;//if sensors[i] has a component ObjectSensor then get incomingObject from it and set to false
        }
    }

    private IEnumerator Move_Routine(Transform transform, Vector3 from, Vector3 to)
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(from, to, Mathf.SmoothStep(0f, 1f, time)*molespeed);
            yield return null;
        }
    }
}
