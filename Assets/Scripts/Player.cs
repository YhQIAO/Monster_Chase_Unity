using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField] // accessiable in inspector
    private float jumpForce = 11f;

    private float movementX;
    

    private Rigidbody2D myBody;
    private Animator myAni;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;
    

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();
    }

    void FixedUpdate()
    {
        // PlayerJump();
    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            myAni.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            myAni.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            myAni.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("enmey"))
        {
            Destroy(gameObject);
        }
    }
}
