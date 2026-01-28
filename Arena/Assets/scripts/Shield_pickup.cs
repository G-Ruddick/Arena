using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_pickup : MonoBehaviour
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
            Destroy(this.transform.gameObject);
            Debug.Log("defense collected!");

            GameManager.Items += 1;
        }
    }
}