using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public SpriteRenderer rend;
    public CapsuleCollider2D boxC;
    [SerializeField] private LayerMask platformLayerMask;
    public Animator animator;

    public float moveSpeed;
    public float jumpForce;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update() {

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;


        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        HandleLayers();

        if (horizontalMovement > 0) {
            rend.flipX = false;
        }

        if (horizontalMovement < 0) {
            rend.flipX = true;
        }

        if (isGrounded()) {
            animator.ResetTrigger("jump");
            animator.SetBool("land", false);
        }

        if (isGrounded() && Input.GetButtonDown("Jump")) {
        rb2d.AddForce(new Vector2(0f, jumpForce));
        animator.SetTrigger("jump");
        }
    }

    void FixedUpdate()
    {
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement) {

        if(rb2d.velocity.y < 0) {
            animator.SetBool("land", true);
        }

        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, .05f);
    }

    private bool isGrounded() {
        float extraHeight = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxC.bounds.center, boxC.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
     /*
        Color rayColor;
        if (raycastHit != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxC.bounds.center + new Vector3(boxC.bounds.extents.x, 0), Vector2.down * (boxC.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxC.bounds.center - new Vector3(boxC.bounds.extents.x, 0), Vector2.down * (boxC.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxC.bounds.center - new Vector3(boxC.bounds.extents.x, boxC.bounds.extents.x), Vector2.right * (boxC.bounds.extents.x), rayColor);
        Debug.Log(raycastHit.collider);
   */
        return raycastHit.collider != null;
    }

    private void HandleLayers() {
        if (!isGrounded()) {
            animator.SetLayerWeight(1, 1);
        } else {
            animator.SetLayerWeight(1, 0);
        }
    }
}
