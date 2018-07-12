using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 startPos;
    private Rigidbody2D rigidBody;

    // Use this for initialization
 

    public void restart() {
        rigidBody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rigidBody.AddForce(new Vector3(-0.5f, 0.5f,0.0f));

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Finish"))
        {
            transform.position=startPos;
            rigidBody.velocity = new Vector3(0, 0, 0);
            GameObject.Find("Peddle").GetComponent<peddle>().resetPos();
            
            GameObject.Find("SuperGame").SetActive(false);
            GameObject.Find("InvisiblePanel").SetActive(false);
        }

    }
}
