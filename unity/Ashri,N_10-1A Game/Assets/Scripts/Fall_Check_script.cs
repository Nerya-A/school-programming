using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall_Check_script : MonoBehaviour
{
    public Transform player_check_pos;
    void Start()
    {
        
    }

    void Update()
    {
        if(this.transform.position.y > player_check_pos.transform.position.y)
        {
            Scene this_Scene = SceneManager.GetActiveScene();
            int Lvl_num = this_Scene.buildIndex;
              SceneManager.LoadScene(Lvl_num);
            Debug.Log("condition works");
        }        
    }
}
