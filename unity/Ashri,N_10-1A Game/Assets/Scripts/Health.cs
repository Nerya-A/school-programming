using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    private Rigidbody2D rigidBody;
    public Text Health_Text;


    void Start()
    {
        health = 100;
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if(health<=0){
            SceneManager.LoadScene(1);
        }
        Health_Text.text = health.ToString();
    }

    void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Enemy"){
                health -= 10 ;
                Debug.Log("Player: " + health);
            }
      } 

}
