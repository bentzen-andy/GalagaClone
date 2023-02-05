using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 10.0f;

    public Rigidbody2D player;

    public AudioSource soundSource;

    public AudioClip explosion;


    // Start is called before the first frame update
    void Start() {
        player = this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update() {
        MovePlayer();
    }

    // Detect if the projectile hits something
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name.Contains("Enemy") || 
            other.gameObject.name.Contains("EnemyProjectile")) {
            Destroy(this.gameObject);
            soundSource.PlayOneShot(explosion);
        }
    }


    private void MovePlayer() {
        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }
}
