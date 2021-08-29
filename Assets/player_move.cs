using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool isFacingRight = true;
    public int playerJumpPower = 100;
    public float moveX;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }

    void playerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(moveX));
        animator.SetFloat("Jump", gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        if (moveX < 0.0f && isFacingRight == true)
        {
            flipPlayer();
        }
        else if (moveX > 0.0f && isFacingRight == false)
        {
            flipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void flipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;



        //wowza
    }
}
