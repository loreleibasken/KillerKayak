using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float upForce;
    public float shieldFlashTime = 0.1f;
    public float shieldPowerUpTime = 2f;
    public Text scoreText;
    public AudioClip pickupClip;
    public AudioClip powerUpClip;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    float shieldTimeLeft = 0;
    int score = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("FlashShip"); // flash ship if shield is active
        UpdateScore();
    }

    void Update()
    {
        // if user presses mouse button, paddle boat up
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, upForce));
        }
        // if the shield is on, decrease how much time is left
        if (shieldTimeLeft > 0f)
        {
            shieldTimeLeft -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Powerup")
        {
            audioSource.PlayOneShot(powerUpClip);
            Destroy(other.gameObject);
            // add some time to the shield
            shieldTimeLeft += shieldPowerUpTime;
        }
    }

    IEnumerator FlashShip()
    {
        while (true)
        {
            Color color = spriteRenderer.color;
            // if the shield is active, flash the boat
            if (shieldTimeLeft > 0f)
            {
                color.a = Random.Range(0f, 1f);
            }
            else // otherwise, set the boat back to normal
            {
                shieldTimeLeft = 0f;
                color.a = 1f;
            }
            spriteRenderer.color = color;
            yield return new WaitForSeconds(shieldFlashTime);
        }
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public bool IsShieldOn()
    {
        return (shieldTimeLeft > 0f);
    }

    public void ObstacleDestroyed(bool obstacleKilled)
    {
        if (obstacleKilled)
        {
            score += 5;
        }
        else
        {
            score += 1;
        }
        if (audioSource != null)
        {
            audioSource.PlayOneShot(pickupClip);
        }
        UpdateScore();
    }

}
