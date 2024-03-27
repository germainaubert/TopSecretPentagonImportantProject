using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float jumpingForce = 10f;
    [SerializeField] private float flyingForce = 5f; 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject interactableAnchor;
    private float horizontalAxis;
    private bool isFacingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Fly();
        }

        Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalAxis * movementSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
        }
    }

    private void Fly()
    {
        rb.velocity = new Vector2(rb.velocity.x, flyingForce);
    }

    private void Flip()
    {
        if (!isFacingRight && horizontalAxis < 0f || isFacingRight && horizontalAxis > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.CircleCast(groundCheck.position, 0.5f, Vector2.down, 0.1f, groundLayer);
    }

    public bool isLookingAtInteractable(GameObject interactable)
    {
        RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, 0.5f, Vector2.right, 1f, interactableLayer);
        if (!raycastHit || !interactable.Equals(raycastHit.collider.gameObject)) return false;
        return true;
    }
}
