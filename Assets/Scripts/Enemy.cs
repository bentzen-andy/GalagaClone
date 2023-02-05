using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D ship;

    public float moveSpeed = 15.0f;

    public bool changeDirection = false;

    public AudioSource soundSource;

    public AudioClip explosion;


    // Start is called before the first frame update
    void Start() {
        ship = this.GetComponent<Rigidbody2D>();
        
    }


    // Update is called once per frame
    void Update() {
        MoveEnemy();
    }


    private void MoveEnemy() {
        Vector2 vecX = new Vector2(1, 0);

        if (changeDirection) ship.velocity = vecX*(-1)*moveSpeed;
        else ship.velocity = vecX*moveSpeed;
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "WallRight") {
            changeDirection = !changeDirection;
        }

        if (other.gameObject.name == "WallLeft") {
            changeDirection = !changeDirection;
        }

        if (other.gameObject.name.Contains("Enemy")) {
            changeDirection = !changeDirection;
        }

        if (other.gameObject.name.Contains("PlayerProjectile")) {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
            soundSource.PlayOneShot(explosion);
        }
    }
}
