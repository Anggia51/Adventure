using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Karakter : MonoBehaviour
{
    public float moveSpeed = 5f;        
    public float jumpForce = 7f;       
    public Transform groundCheck;      
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;       

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastScene", currentScene);
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void HandleMovement()
    {
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
            spriteRenderer.flipX = false;
        }

        if (isGrounded)
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed * 0.8f, rb.velocity.y);
        }
    }


    void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = collision.transform;
        }

        if (collision.contacts.Length > 0)
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            // Jika menyentuh tembok dari samping (normal arah kiri/kanan)
            if (Mathf.Abs(normal.x) > 0.5f)
            {
                // Dorong jatuh
                rb.velocity = new Vector2(0, rb.velocity.y - 1f);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;
        }
    }
}