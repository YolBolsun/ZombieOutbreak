using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    bool thirdPerson = false;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public float thirdPersonCameraDistance;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        ToggleView();
        thirdPersonCamera.transform.position = transform.position - transform.forward * thirdPersonCameraDistance +transform.up*1.5f;
	}
    void ToggleView()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (thirdPerson)
            {
                firstPersonCamera.enabled = true;
                thirdPersonCamera.enabled = false;
                thirdPerson = !thirdPerson;
            }
            else
            {
                firstPersonCamera.enabled = false;
                thirdPersonCamera.enabled = true;
                thirdPerson = !thirdPerson;
            }
        }
    }
}
