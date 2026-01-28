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
                GameManager.Items += 1;
                playerMovement.MoveSpeed *= 3f;
                playerMovement.speedBoost = true;
            }
        }
    }
}