using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RBD2;
    [SerializeField] private float speed = 5f;
    private Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = movementInput * speed;
        RBD2.velocity = movement;
    }
    public void ReadDirection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>(); 
        }
        else if (context.canceled)
        {
            movementInput = Vector2.zero; 
        }
    }
}
