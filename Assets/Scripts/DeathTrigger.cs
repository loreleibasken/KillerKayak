using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{

    Movement movement;

	void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        movement = playerObject.GetComponent<Movement>();
	}

    void Update()
    {
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (movement.IsShieldOn())
            {
                if (tag == "Obstacle")
                {
                    movement.ObstacleDestroyed(true);
                    Destroy(gameObject);
                }
            }
            else
            {
                PlayerDie(other.gameObject);
            }
        }
    }

    void PlayerDie(GameObject obstacle)
    {
        Destroy(obstacle);
        SceneManager.LoadScene(2);
    }

}
