using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f; // Speed of movement
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform spawn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         if (spawn != null)
    {
        transform.position = spawn.position;
    }
    }

    void Update()
    {
        // Get input (WASD or Arrow Keys)
        moveInput.x = Input.GetAxisRaw("Horizontal");
       
        moveInput.Normalize(); // Prevent faster diagonal movement
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        /* (INPROGRESS)
        if(Input.GetKeyDown(KeyCode.Space)){
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 5f); //jump 
        } */
    }
    void OnDrawGizmosSelected()
{
    if (groundCheck != null)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

    void FixedUpdate()
    {
      rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }
}