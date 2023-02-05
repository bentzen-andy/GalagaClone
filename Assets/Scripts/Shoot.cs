using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject projectile;

    public Transform projectileSpawn;

    public float nextFire = 0.5f;

    public float currTime = 0.0f;

    public AudioSource soundSource;

    public AudioClip laserSound;


    // Start is called before the first frame update
    void Start() {
        projectileSpawn = this.gameObject.transform;
    }


    // Update is called once per frame
    void Update() {
        ShootProjectile();
    }


    private void ShootProjectile() {
        currTime += Time.deltaTime;
        if ((Input.GetButton("Fire1") || Input.GetKey("space")) && currTime > nextFire) {
            nextFire += currTime;

            // this will shoot the gun
            Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            soundSource.PlayOneShot(laserSound);

            nextFire -= currTime; 
            currTime = 0.0f;
        }
    }
}
