using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    public Transform[] puntos;
    public float speed = 2f;
    public float persiguiendo = 4f;
    public float rango = 5f;
    public Transform player;
    public LayerMask layerMask;

    private int puntoActual = 0;
    private bool ischasing = false;

    private void Update()
    {
        if (ischasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrullaje();
        }

        Comprobar();
    }

    private void Patrullaje()
    {
        Transform punto = puntos[puntoActual];
        Vector2 direction = (punto.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, punto.position) < 0.1f)
        {
            puntoActual = (puntoActual + 1) % puntos.Length;
        }
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * persiguiendo * Time.deltaTime);
    }

    private void Comprobar()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.position - transform.position).normalized, rango, layerMask);
        if (hit.collider != null && hit.collider.transform == player)
        {
            ischasing = true;
        }
        else
        {
            ischasing = false;
        }
    }
}
