using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shoot : NetworkBehaviour {

    public GameObject equippedWeapon;

    private Weapon weapon;
    private float timeBetweenShots;
    private float timeOfLastShot = 0f;

    // Use this for initialization
    [ClientCallback]
    void Start () {
        weapon = equippedWeapon.GetComponent<Weapon>();
        timeBetweenShots = 1f / weapon.shotsPerSecond;
	}

    // Update is called once per frame
    [ClientCallback]
    void Update () {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > (timeOfLastShot + timeBetweenShots))
        {
            Debug.Log("spawn1");
            timeOfLastShot = Time.time;
            
            CmdFire(Camera.main.transform.position, transform.forward);
        }
	}

    [Command]
    void CmdFire(Vector3 position, Vector3 forward)
    {
        Debug.Log("Spawn2");
        // GameObject bullet = (GameObject)Instantiate(equippedWeapon, transform.position + transform.forward*2, Quaternion.identity);

        // GameObject.Destroy(bullet, 2f);
        GameObject bullet = (GameObject)Instantiate(equippedWeapon, position + forward * 2, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(bullet,connectionToClient);
        TargetSpawnBullet(connectionToClient, bullet);

    }
    [TargetRpc]
    public void TargetSpawnBullet(NetworkConnection conn, GameObject bullet)
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), bullet.GetComponent<Collider>());
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * equippedWeapon.GetComponent<Weapon>().speed);
        GameObject.Destroy(bullet, 2f);
    }
}
