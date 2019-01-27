using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets;

public class SetupLocalPlayer : NetworkBehaviour {

    

	// Use this for initialization
	void Start () {
	    if(isLocalPlayer)
        {
             //GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<Shoot>().enabled = true;
            GetComponent<CameraControl>().enabled = true;
            GetComponent<PlayerHealth>().enabled = true;
            gameObject.GetComponentInChildren<Camera>().enabled = true;
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
            gameObject.GetComponentInChildren<AudioListener>().enabled = true;
        }	
	}
}
