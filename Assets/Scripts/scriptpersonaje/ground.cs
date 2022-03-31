using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private float jumpHeight = 4f;
    [SerializeField] private LayerMask jumpableLayers;
    [Range(0,1)]
    [SerializeField] private float jumpVelModifer = 1f;
    [SerializeField] private float climbSpeed = 3f;
    
    [SerializeField] private LayerMask climbableLayers;
    private Rigidbody2D rb;
    private CapsuleCollider2D bodycapCollider;
    private BoxCollider2D feetboxCollider;
    private Animator animator;

    private float gravityScale = 1f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        bodycapCollider = GetComponent<CapsuleCollider2D>();
        feetboxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        gravityScale =  rb.gravityScale;
    }
    
    void Start()
    {     

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void move(float moveX){
        rb.velocity = new Vector2 ( moveX * walkSpeed, rb.velocity.y );
        if (moveX != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
       
    }

    public void Climb(float moveY)
    {

        if (!bodycapCollider.IsTouchingLayers(climbableLayers) || !feetboxCollider.IsTouchingLayers(climbableLayers))
        {

            rb.gravityScale = gravityScale;
            return;

        }
        rb.velocity = new Vector2(rb.velocity.x, moveY * climbSpeed);
        rb.gravityScale = 0f;

    }

    public void jump(bool value)
    {
        //if (!capCollider.IsTouchingLayers(jumpableLayers)){return;}

        if (value){

            if (feetboxCollider.IsTouchingLayers(jumpableLayers))
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(-2f * gravityScale * Physics2D.gravity.y * jumpHeight));
            }
            //rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            
        }
        else
        {
            if(rb.velocity.y > Mathf.Epsilon){

                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpVelModifer);
            }
        }
    }

    public void FlipTransform ( float moveX ) 
    {   
        transform.localScale = new Vector2( Mathf.Sign(moveX), 1f);
    }


}