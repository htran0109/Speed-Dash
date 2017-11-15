using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2.0f;
    public float jumpForce = 300f;

    private bool grounded = true;
    private bool doubleJump = true;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        readKeys();
	}

    void readKeys()
    {
        float xInput = Input.GetAxis("Horizontal") * speed;
        xInput *= Time.deltaTime;
        transform.Translate(xInput, rb2d.velocity.y*Time.deltaTime, 0);
        if(Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                grounded = false;
                doubleJump = true;
                rb2d.velocity = (new Vector2(rb2d.velocity.x, 0));
                rb2d.AddForce(new Vector2(0, jumpForce));
            }
            else if(doubleJump)
            {
                doubleJump = false;
                rb2d.velocity = (new Vector2(rb2d.velocity.x, 0));
                rb2d.AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ground")
        {
            grounded = true;

        }
    }

}
