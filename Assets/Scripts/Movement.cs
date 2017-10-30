using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float upForce;

    Rigidbody2D rigidBody;               

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, upForce));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Powerup")
        {
            Debug.Log("POWERUP");
            Destroy(other.gameObject);
        }
    }

}
