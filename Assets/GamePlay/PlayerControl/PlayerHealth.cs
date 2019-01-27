using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerHealth : NetworkBehaviour {

    [SyncVar]
    public float health = 100f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("Collision");
        if(coll.gameObject.CompareTag("Weapon"))
        {
            health -= coll.gameObject.GetComponent<Weapon>().damage;
            GameObject.Destroy(coll.gameObject);
            if(health <= 0)
            {
                SceneManager.LoadScene("lossScreen");
            }
        }
    }

}
