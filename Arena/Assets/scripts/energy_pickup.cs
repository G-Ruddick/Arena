using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_pickup : MonoBehaviour
{    
    public GameBehavior GameManager;

    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    public PlayerBehavior playerMovement;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement = collision.gameObject.GetComponent<PlayerBehavior>();

            if (playerMovement != null)
            {
                Destroy(gameObject);
                Debug.Log("Item collected!");

                GameManager.Items += 1;

                playerMovement.MoveSpeed *= 1.2f;
            }
        }
    }
}