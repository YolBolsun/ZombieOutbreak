using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicZombieAI : MonoBehaviour {

    public float movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Mathf.Round(Time.timeSinceLevelLoad)%2==1)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
        else {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
		
	}
}
