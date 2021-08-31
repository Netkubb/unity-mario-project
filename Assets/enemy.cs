using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{

    public GameObject player;
    public float enemySpeed;
    private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = false;
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
    }
}
