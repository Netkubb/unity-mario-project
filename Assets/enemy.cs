using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{

    public GameObject player;
    public float enemySpeed;
    private bool isFacingRight;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = false;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = player.transform.position.x;
        float enemyX = transform.position.x;
        if (enemyX > playerX && isFacingRight == true)
        {
            FlipEnemy();
        }
        else if (enemyX < playerX && isFacingRight == false)
        {
            FlipEnemy();
        }
        if (isFacingRight)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemySpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void FlipEnemy()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = transform.localScale * new Vector2(-1, 1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (other.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
        }
    }

    public void getHitted(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            gameObject.GetComponents<Collider2D>()[0].enabled = false;
            gameObject.GetComponents<Collider2D>()[1].enabled = false;

            this.enabled = false;
        }
    }
}
