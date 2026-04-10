using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script
{
    public class PlayerController : MonoBehaviour
    {
        [Tooltip("Vitesse de déplacement (unités/sec).")]
        public float speed = 5.0f;

        [Tooltip("Force du saut.")]
        public float jumpForce = 7f;

        private Rigidbody2D rb;
        private bool _isGrounded = false;
        private bool _jumpRequested = false;
    
        Animator animator;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null) Debug.LogWarning("PlayerController nécessite un Rigidbody2D.");
        
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
                _jumpRequested = true;
        
            // Saut
            if (_jumpRequested && _isGrounded)
            {
                // La solutidon ;)
                // rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                _isGrounded = false;
            }
            _jumpRequested = false;
        
            float moveX = 0f;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                moveX = -1f;
            }
        
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                moveX =  1f;
            }

            // Déplacement via vélocité (compatible avec AddForce)
            rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
            
            
        
            // Flip du sprite
            if (moveX != 0f)
                transform.localScale = new Vector3(
                    Mathf.Abs(transform.localScale.x) * Mathf.Sign(moveX),
                    transform.localScale.y,
                    transform.localScale.z
                );
        
        }

        private void FixedUpdate()
        {
        
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    _isGrounded = true;
                    break;
                }
            }
        }
    }
}