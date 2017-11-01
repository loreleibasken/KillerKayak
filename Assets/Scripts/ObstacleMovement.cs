using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float speed = -1f;
    public float minX = -15f;

    Rigidbody2D rigidBody;
    Movement movement;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.right * speed;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        movement = playerObject.GetComponent<Movement>();
    }

    void Update()
    {
        if (rigidBody.transform.position.x < minX)
        {
            movement.ObstacleDestroyed(false);
            Destroy(gameObject);
        }
    }

}
