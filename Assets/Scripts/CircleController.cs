using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float startSpeed;
    public float speedIncrease;
    public float jumpForce;

    [HideInInspector]
    public float speed;

    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Collider2D circleCollider;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<Collider2D>();

        speed = startSpeed;
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        speed += speedIncrease * Time.deltaTime;
    }

    bool IsGrounded()
    {
        return Physics2D.IsTouchingLayers(circleCollider, whatIsGround);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
