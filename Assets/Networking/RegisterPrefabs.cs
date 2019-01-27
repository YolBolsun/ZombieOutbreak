using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RegisterPrefabs : NetworkBehaviour {

    public GameObject prefab;

    public override void OnStartClient()
    {
        ClientScene.RegisterPrefab(prefab);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
