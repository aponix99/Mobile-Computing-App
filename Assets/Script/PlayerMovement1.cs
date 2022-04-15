using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=4f;
    Rigidbody2D rb;
    private Vector3 change;
    private Animator animator;

    public Joystick joystick;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        change = Vector3.zero;
         change.x = joystick.Horizontal;
        change.y = joystick.Vertical;
       // change.x = Input.GetAxisRaw("Horizontal");
        //change.y = Input.GetAxisRaw("Vertical");
        updateAnimationsAndMove();
    }

    void updateAnimationsAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
