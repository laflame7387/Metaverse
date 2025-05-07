using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    float jumpForce = 6f;
    float fowardSpeed = 3f;
    bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    bool godMode = false;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null )
        {
            Debug.LogError("Not Founded Animator");
        }
        if ( _rigidbody == null )
        {
            Debug.LogError("Not Founded RigidBody");
        }
    }
    private void Update()
    {
        if(isDead)
        {
            if(deathCooldown > 0)
                deathCooldown -= Time.deltaTime;
            
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = fowardSpeed;

        if(isFlap)
        {
            velocity.y += jumpForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp( (_rigidbody.velocity.y * 10f) , -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (godMode) return;
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("isDie", 1);
        gameManager.GameOver();
    }

}
