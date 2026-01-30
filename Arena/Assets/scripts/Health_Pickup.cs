using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{    
    public GameBehavior GameManager;

    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameManager.Items += 1;
            GameManager.AddHP(1);
            Destroy(transform.gameObject);
        }
    }
} 