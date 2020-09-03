using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI : MonoBehaviour
{
    //boundaries for enemy movement
    private float left_max;
    private float right_max;
    private bool facing_left = true;
    public float enemy_speed;
    //movement components
    private Collider2D cld;
    private Rigidbody2D rb;
    //    private bool checkMotion;

    void Start()
    {
        cld = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        facing_left = true;
        left_max = transform.position.x - 18f;
        right_max = transform.position.x + 18f;
        enemy_speed = 50f;


    }
    
    private void FixedUpdate()
    {
        if (facing_left)
        {
            if (transform.position.x > left_max)
            {
                if (transform.localScale.x != 7)
                {
                    transform.localScale = new Vector3(7, 8);
                }

                rb.velocity = new Vector2(-enemy_speed, rb.velocity.y);
            }
            else
            {
                facing_left = false;
            }
        }
        else
        {
            if (transform.position.x < right_max)
            {
                if (transform.localScale.x != -7)
                {
                    transform.localScale = new Vector3(-7, 8);
                }

                rb.velocity = new Vector2(enemy_speed, rb.velocity.y);
            }
            if (transform.position.x >= right_max)
            {
                facing_left = true;
            }
        }

    }
}