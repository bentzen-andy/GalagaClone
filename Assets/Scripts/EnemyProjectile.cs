using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
   
    public Rigidbody2D projectile;

    public float moveSpeed = 20.0f; 

    // Start is called before the first frame update
    void Start() {
        projectile = this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update() {
        Move();
    }


    // Detect if the projectile hits something
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "WallBottom") {
            Destroy(this.gameObject);
        }
    
    }


    private void Move(){
        projectile.velocity = new Vector2(0, -1) * moveSpeed;
    }
}
