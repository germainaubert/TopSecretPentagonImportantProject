using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float jumpingForce = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject interactableAnchor; // anchor is slighlty positionned on the front of the character to prevent interactions when the player is not looking at the object
    private float horizontalAxis;
    private bool isFacingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // jump
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
        }

        Flip();
    }

    void FixedUpdate()
    {
        // x axis movement
        rb.velocity = new Vector2(horizontalAxis * movementSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        if(!isFacingRight && horizontalAxis <0f || isFacingRight && horizontalAxis > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded()
    {
        if (Physics2D.CircleCast(groundCheck.transform.position, 0.5f, Vector2.down, 0.1f, groundLayer))
        {
            return true;
        }
        else {
            return false;
        }
    }

    public bool isLookingAtInteractable(GameObject interactable)
    {
        RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, 0.5f, Vector2.right, 1f, interactableLayer);
        if (!raycastHit || !interactable.Equals(raycastHit.collider.gameObject)) return false;
        return true;
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
