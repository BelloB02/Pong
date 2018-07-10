using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    private Rigidbody2D rb2d;
    Vector2 vel;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Move", 1); //calls the Move function
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move() //Determines randomly for the ball to begin moving to the left or to the right whenever the ball spawns in the middle
    {
        float rand = Random.Range(0, 2); //draws a random number
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        } else if (rand >= 1)
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //when the ball hits a paddle, bounces off with continuous velocity
    {
        if (collision.collider.CompareTag("Player"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y + 1) + (collision.collider.attachedRigidbody.velocity.y + 1);
            rb2d.velocity = vel;
        }
    }

    void Reset() //Resets the ball to its starting position and sets its velocity to 0
    {
        vel = Vector2.zero;
        rb2d.velocity = vel;
        transform.position = Vector2.zero;
    }

    void Restart() //Restarts the game
    {
        Reset();
        Invoke("Move", 1);
    }
}
