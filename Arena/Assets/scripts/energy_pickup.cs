using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class enemy_pickup : MonoBehaviour
{    
    public PlayerBehavior playerMovement;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement = collision.gameObject.GetComponent<PlayerBehavior>();

            if (playerMovement != null)
            {
                Destroy(gameObject);
                UnityEngine.Debug.Log("Item collected!");

                playerMovement.MoveSpeed *= 1.2f;
            }
        }
    }
}