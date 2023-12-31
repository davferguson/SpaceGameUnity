using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(100.0f, 100.0f); // 2D Movement speed to have independant axis speed
    private new Rigidbody2D rigidbody2D; // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    private Animator animator;
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);

    void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // if(inputVector.x != 0){
        //     animator.SetFloat("LastDirection", inputVector.x);
        //     animator.SetFloat("Horizontal", inputVector.x);
        //     animator.SetFloat("Vertical", inputVector.y);
        // }
        // if(inputVector.y != 0){
        //     animator.SetFloat("Vertical", inputVector.y);
        // }

        animator.SetFloat("Horizontal", inputVector.x);
        animator.SetFloat("Vertical", inputVector.y);
        
        if(inputVector.x != 0){
            animator.SetFloat("LastHorizontal", inputVector.x);
            animator.SetFloat("LastVertical", 0);
        }
        if(inputVector.y != 0){
            animator.SetFloat("LastVertical", inputVector.y);
            animator.SetFloat("LastHorizontal", 0);
        }

        animator.SetFloat("Speed", inputVector.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }
}
