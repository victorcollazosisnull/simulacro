using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public Transform posicionInicio; 
    public float moveSpeed = 3f; 
    public float zonaDetecta = 5f; 
    public Transform player;
    private bool isPlayerComing = false;

    private void Update()
    {
        if (isPlayerComing)
        {
            IrAlPlayer();
        }
        else
        {
            VolverAlPunto();
        }
    }

    private void IrAlPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void VolverAlPunto()
    {
        Vector2 direction = (posicionInicio.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, posicionInicio.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player)
        {
            isPlayerComing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == player)
        {
            isPlayerComing = false;
        }
    }
}
