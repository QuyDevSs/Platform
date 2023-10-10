using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance = null;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerController>();
            }
            return instance;
        }
    }
    void OnDestroy()
    {
        instance = null;
    }
    enum State
    {
        idle,
        dead,
        attack,
        throw_,
        climb,
        run,
        jump,
        slide,
        glide,
        jumpAttack,
        jumpThrow

    }

    State state;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    float dirX;
    float dirY;

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float slideForce;

    bool isAttacking = false;
    bool isThrowing = false;
    bool isRuning = false;
    bool isJumping = false;
    bool isClimbing = false;
    bool isSliding = false;
    bool isGliding = false;

    void Start()
    {
        state = State.idle;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == true)
        {
            isClimbing = true;
            rb.velocity = Vector2.zero;
            //rb.gravityScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == true)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == true)
        {
            rb.gravityScale = 3;
            isClimbing = false;
        }
    }
    void Update()
    {
        Debug.Log(state);
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        updateDir();
        if (state != State.slide && state != State.attack && state != State.throw_ && state != State.climb)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            isThrowing = true;
        }
        else if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, jumpForce);
            isJumping = true;
        }
        else if (dirY < 0 && rb.velocity.y == 0 && state == State.idle)
        {
            isSliding = true;
            if (sprite.flipX)
            {
                rb.velocity = new Vector2(-slideForce, 0);
            }
            else
            {
                rb.velocity = new Vector2(slideForce, 0);
            }
        }
        else if (rb.velocity.y == 0 && dirX > 0)
        {
            isRuning = true;
        }
        else if (rb.velocity.y == 0 && dirX < 0)
        {
             isRuning = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isThrowing = false;
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            isSliding = false;
        }

        if (rb.velocity.y == 0)
        {
            isJumping = false;
        }
        if (dirX == 0)
        {
            isRuning = false;
        }
        if (rb.velocity.x == 0 || isJumping || isAttacking || isThrowing)
        {
            isSliding = false;
        }
        updateState();
        animationState();
    }

    void updateState()
    {
        if (isSliding)
        {
            state = State.slide;
        }
        else if (isAttacking && isJumping)
        {
            state = State.jumpAttack;
        }
        else if (isThrowing && isJumping)
        {
            state = State.jumpThrow;
        }
        else if (isAttacking)
        {
            state = State.attack;
        }
        else if (isThrowing)
        {
            state = State.throw_;
        }
        else if (isJumping)
        {
            state = State.jump;
        }
        else if (isGliding)
        {
            state = State.glide;
        }
        else if (isClimbing)
        {
            state = State.climb;
        }
        else if (isRuning)
        {
            state = State.run;
        }
        else
        {
            state = State.idle;
        }
    }

    void animationState()
    {
        switch (state)
        {
            case State.idle:
                anim.Play("Idle");
                break;
            case State.dead:
                anim.Play("Dead");
                break;
            case State.attack:
                anim.Play("Attack");
                break;
            case State.throw_:
                anim.Play("Throw");
                break;
            case State.climb:
                anim.Play("Climb");
                break;
            case State.run:
                anim.Play("Run");
                break;
            case State.jump:
                anim.Play("Jump");
                break;
            case State.slide:
                anim.Play("Slide");
                break;
            case State.glide:
                anim.Play("Glide");
                break;
            case State.jumpAttack:
                anim.Play("JumpAttack");
                break;
            case State.jumpThrow:
                anim.Play("JumpThrow");
                break;
            default:
                break;
        }
    }
    void updateDir()
    {
        if (dirX > 0)
        {
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            sprite.flipX = true;
        }
    }
}
