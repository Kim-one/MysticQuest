using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public int maxHealth = 5;
    public int curHealth;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;
        if (Input.GetKey(KeyCode.UpArrow)) { 
            vertical = 0.5f;
        }else if(Input.GetKey(KeyCode.RightArrow)){
            horizontal = 0.1f;
        }

        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            Destroy(player);
            curHealth--;
            Instantiate(player, new Vector3(-5f, 0, 0), Quaternion.identity);
            Debug.Log("Collision Detected. Players new health is: " + curHealth);
            if (curHealth == 0) { 
                Destroy(player);
            }
        }
    }
}
