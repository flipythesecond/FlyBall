using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;
    private bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }
    void Flap()
    {
        rb.linearVelocity = Vector2.up * flapForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
           
        }
    }
}
