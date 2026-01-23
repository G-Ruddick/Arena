using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible_pickup : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Renderer playerRenderer = collision.gameObject.GetComponent<Renderer>();

            if (playerRenderer != null)
            {
                MakePlayerTransparent(playerRenderer);
            }

            Destroy(gameObject);
        }
    }

    void MakePlayerTransparent(Renderer renderer)
    {
        Material mat = renderer.material; // creates instance (safe)

        Color color = mat.color;
        color.a = 0.5f; // 50% transparency
        mat.color = color;
    }
}