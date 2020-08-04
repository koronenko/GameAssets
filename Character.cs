using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    bool OnGround;
    public int Lives = 3;
    public float speed = 4.0f;
    public float jumpforce = 1.0f;
    public Rigidbody2D PlayerRigidbody;
    public Animator charAnimator;
    public SpriteRenderer sprite;

    private void Awake()
    {
        PlayerRigidbody = GetComponentInChildren<Rigidbody2D>();
        charAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

     void Move()
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        charAnimator.SetInteger("State", 1);
       
        if (tempvector.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    void Jump()
    {
        PlayerRigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.3f);
        OnGround = colliders.Length > 1;
        Debug.Log(colliders.Length);
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Move();
           // charAnimator.SetInteger("State", 1);
        }
       // else
        //{
        //    charAnimator.SetInteger("State", 0);
       // }
        //if (OnGround && Input.GetButton("Jump"))
        if (Input.GetButton("Jump"))
        {
            Jump();
            charAnimator.SetInteger("State", 2);
        }
        //else
        //{
          //  charAnimator.SetInteger("State", 0);
        //}
    
if (!Input.anyKey)
        {
             charAnimator.SetInteger("State", 0);
        }   
    }
}