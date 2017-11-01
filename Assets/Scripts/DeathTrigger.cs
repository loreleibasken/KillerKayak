using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{

    public AudioClip deathClip;

    Movement movement;
    AudioSource audioSource;

	void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        movement = playerObject.GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
	}

    void Update()
    {
	}

    void OnTriggerEnter2D(Collider2D other)
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
                audioSource.PlayOneShot(deathClip);
                Destroy(other.gameObject);
                Invoke("PlayerDie", 2f);
            }
        }
    }

    void PlayerDie()
    {
        SceneManager.LoadScene(2);
    }

}
