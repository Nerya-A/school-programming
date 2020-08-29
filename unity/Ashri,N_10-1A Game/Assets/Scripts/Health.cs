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
        health = 50;
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if(health<=0){
            Scene this_Scene = SceneManager.GetActiveScene();
            int Lvl_num = this_Scene.buildIndex;
            SceneManager.LoadScene(Lvl_num);
        }
        Health_Text.text = health.ToString();
    }

    void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Enemy"){
                health -= 10 ;
                Debug.Log("Player: " + health);
            //rigidbody.Addforce(new Vector2(this.gameObject.transform.position.x - 100f, this.gameObject.transform.position.y + 100f));
            //Debug.Log(this.gameObject.transform);
        }
    } 

}
