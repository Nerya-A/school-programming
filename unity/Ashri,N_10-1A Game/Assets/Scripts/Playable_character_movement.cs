using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Playable_character_movement : MonoBehaviour {

public float speed;
public float jump_speed;
public float motion;
private Rigidbody2D rigidBody;
private Vector2 startpos; 
public LayerMask groundLayer;
private PolygonCollider2D PolyCollider;
private Health health;
private const float INITIAL_SPEED = 20f;
private Animator playerAnimation;
//private enum State {idle, running, jumping, falling};
//private State state = State.idle; 
public Text JumpText;


    void Start()
    {
     health = this.gameObject.GetComponent<Health>();
     rigidBody = GetComponent<Rigidbody2D>();
     speed = INITIAL_SPEED;
     motion = 0f;
     jump_speed = 50f;   
     startpos = this.transform.position;
     PolyCollider = transform.GetComponent<PolygonCollider2D>();
     playerAnimation = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        JumpText.text = speed.ToString();
        motion = Input.GetAxis("Horizontal");
        //Debug.Log("speed:" + speed);
        if(motion<0f) {
            //Debug.Log("motion left");
            //Debug.Log(motion);
            rigidBody.velocity = new Vector2(motion*speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-8.625046f, 9.756044f);
        }

        else if(motion>0f) {
            //Debug.Log("motion right");
            rigidBody.velocity = new Vector2(motion*speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(8.625046f, 9.756044f);
            }
            if(PlayerGround() && Input.GetButtonDown("Jump")) {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x,Mathf.Abs(motion/2)*jump_speed+10f);
                speed -= 4.0f;
        }
            if(speed <= 0) {
                this.transform.position = startpos;
                speed = INITIAL_SPEED;
            }
        playerAnimation.SetFloat("Movemnt", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", PlayerGround());
        playerAnimation.SetFloat("Speed2", speed);
    }
        //void OnTriggerEnter2D(Collider2D Tilemap) {
          //  speed -= 2.0f;
       // }
        private bool PlayerGround() {
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(PolyCollider.bounds.center, PolyCollider.bounds.size, 0f, Vector2.down, .1f, groundLayer);
                         
             Debug.Log("Raycast");
             return raycastHit2D.collider != null;
           }
        void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Enemy" && other.gameObject.transform.GetChild(0).tag == "Enemy_Hitbox"&& PlayerGround()== false) {
                //Debug.Log("jumpted on ya");
               rigidBody.velocity = new Vector2(rigidBody.velocity.x, 7f);
               health.health += 10;
               speed = INITIAL_SPEED;
            }
        }
}
