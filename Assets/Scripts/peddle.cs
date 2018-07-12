using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peddle : MonoBehaviour {

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    private bool canLeft = true;
    private bool canRight = true;

    public float speed = 100.0f;
    private Rigidbody2D rigidBody;
    Vector3 startpos;
    // Use this for initialization
    public void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        startpos = transform.position;
	}

    public void resetPos() {
        transform.position = startpos;
    }
	// Update is called once per frame
	void Update () {
        Vector3 vel = rigidBody.velocity;
        if (Input.GetKey(right)&& canRight)
        {
            vel.x = speed;
        }
        else if (Input.GetKey(left) && canLeft)
        {
            vel.x = -speed;
        }
        else if (!Input.anyKey)
        {
            vel.x = 0;
        }
        rigidBody.velocity = vel;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidBody.velocity = new Vector3(0,0,0);
        if (collision.name=="ColliderLeft")
        {
            canLeft = false;
        }
        else if (collision.name== "ColliderRight") {
            canRight = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name== "ColliderLeft")
        {
            canLeft = true;
        }
        else if (collision.name== "ColliderRight")
        {
            canRight = true;
        }
    }
}
