using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    
    public GameObject projectile;

    public Transform projectileSpawn;

    public float nextFire = nextFireBaseTime;

    public float currTime = 0.0f;

    public AudioSource soundSource;

    public AudioClip laserSound;

    private static float nextFireBaseTime = 40.0f;

    
    // Start is called before the first frame update
    void Start() {
        projectileSpawn = this.gameObject.transform;
        RandomizeCurrentShootTime();
    }


    // Update is called once per frame
    void Update() {
        ShootProjectile();
    }


    private void ShootProjectile() {
        currTime += Time.deltaTime;

        if (Time.time > 15 && nextFire > nextFireBaseTime/2)  { nextFire = nextFireBaseTime/2; RandomizeCurrentShootTime(); }
        if (Time.time > 30 && nextFire > nextFireBaseTime/4)  { nextFire = nextFireBaseTime/4; RandomizeCurrentShootTime(); }
        if (Time.time > 45 && nextFire > nextFireBaseTime/8)  { nextFire = nextFireBaseTime/8; RandomizeCurrentShootTime(); }
        if (Time.time > 60 && nextFire > nextFireBaseTime/16) { nextFire = nextFireBaseTime/16; RandomizeCurrentShootTime(); }
        if (Time.time > 75 && nextFire > nextFireBaseTime/32) { nextFire = nextFireBaseTime/32; RandomizeCurrentShootTime(); }

        if (currTime > nextFire) {
            // this will shoot the gun
            Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            soundSource.PlayOneShot(laserSound);
            
            RandomizeCurrentShootTime();
        }
    }

    
    private void RandomizeCurrentShootTime() {
        var rand = new System.Random();
        float randomNumber;
        randomNumber = (float) rand.NextDouble()*nextFire;

        currTime = 0.0f + randomNumber;
    }

}
