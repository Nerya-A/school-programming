using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Enemy_Health : MonoBehaviour
{
    public float Enemy_health;
    public Transform transform_pos;
    public Playable_character_movement other;
    private bool IsPlayerGround;
    public GameObject Player;

    void Start()
    {
        Enemy_health = 1;
     //   IsPlayerGround = Turrent_Enemy.GetComponent<Playable_character_movement>().PlayerGround();
     }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Enemy_health<=0) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Character" && transform_pos.position.y - 3f > this.transform.position.y)
        {
                Enemy_health -= 1 ;
                Debug.Log("Enemy: " + Enemy_health);
            }
    }
}
