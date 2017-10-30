using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float speed = -1f;
    public float minX = -15f;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.right * speed;
    }

    void Update()
    {
        if (rigidBody.transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }

}
