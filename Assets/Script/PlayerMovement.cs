using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f; 
    private Rigidbody2D rb;   
    public float horizontalInputPublic;
    int groundLayer;
    private Animator animator;

    void Start()
    {
        // Ambil komponen rigidbody dari objek player
        rb=GetComponent<Rigidbody2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
        groundLayer = LayerMask.GetMask("Ground");
        animator = GetComponent<Animator>();
    }

    private void ScaleFlip(float horizontalInput)
    {
        if (horizontalInput < 0) 
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }  
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }

    #region AnimationHandler

    private void PlayWalk()
    {
        animator.SetTrigger("goWalk");
    }

    private void PlayJump()
    {
        animator.SetTrigger("goJump");
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        horizontalInputPublic = horizontalInput;
        ScaleFlip(horizontalInput);

        // Mengaktifkan lompatan player jika player menyentuh tanah
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
           rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
           PlayJump();
        }
    }
}
