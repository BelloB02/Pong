using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public KeyCode moveup = KeyCode.W;
    public KeyCode movedown = KeyCode.S;
    public float speed = 10.0f;
    public float barrierY = 3f;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //
        var vel = rb2d.velocity;
        if (Input.GetKey(moveup)) //Pressing W moves the paddle up
        {
            vel.y = speed;
        } else if (Input.GetKey(movedown)) //Pressing D moves the paddle down
        {
            vel.y = -speed;
        } else if (!Input.anyKey) //Pressing nothing has the paddle remain still
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position; 
        if (pos.y > barrierY)
        {
            pos.y = barrierY; //if the paddle tries to move above the top barrier, stop it from doing so
        } else if (pos.y < -barrierY)
        {
            pos.y = -barrierY; //if the paddle tries to move below the bottom barrier, stop it from doing so
        }
        transform.position = pos;

	}
}
