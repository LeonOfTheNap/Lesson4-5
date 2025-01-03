using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]private float jumpForce;
    [SerializeField]private float liftingForce;
    
    [SerializeField]private bool jumped;
    [SerializeField]private bool doubleJumped;

    public LayerMask whatIsGround;
    
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float timestamp;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); // dohvat komponenete RigidBody 2D
        boxCollider = GetComponent<BoxCollider2D>(); //dohvat komponente BoxCollider 2D
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, 
            boxCollider.bounds.size, 
            0f, Vector2.down, 0.1f, whatIsGround);
        return hit.collider != null;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.inGame) return;
        
        if(IsGrounded() && Time.time >= timestamp)
        {
            if (jumped || doubleJumped)
            {
                jumped = false;
                doubleJumped = false;
            }
            
            timestamp = Time.time + 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jumped)
            {
                rb.velocity = new Vector2(0f, jumpForce);
                jumped = true;
            } else if (!doubleJumped)
            {
                rb.velocity = new Vector2(0f, liftingForce);
                doubleJumped = true;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //ako je player "udario" GameObject s Tagom "Obstacle", pokreni funkciju playerDeath()
        if (other.CompareTag("Obstacle"))
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        //zaustavi svu fiziku koja utječe na player-a
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        
        GameManager.instance.GameOver();
    }
}
