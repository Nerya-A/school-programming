using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Enemy_Health : MonoBehaviour
{
    public float Enemy_health;

    void Start()
    {
        Enemy_health = 3;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Enemy_health<=0) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Character"){
                Enemy_health -= 1 ;
                Debug.Log("Enemy: " + Enemy_health);
            }
    }
}
