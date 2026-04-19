using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;
    private bool isDead = false;

    public float maxUpAngle = 30f;
    public float maxDownAngle = -90f;
    public float rotationSpeed = 5f;
    public AudioSource jumpAudio;
    public AudioSource pointAudio;
    public AudioSource gameOverAudio;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame ||
            Mouse.current.leftButton.wasPressedThisFrame ||
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Flap();
        }
        RotateBird();
    }
    void Flap()
    {
        rb.linearVelocity = Vector2.up * flapForce;
        if (jumpAudio != null)
        {
            jumpAudio.Play();
        }
    }

    void RotateBird()
    {
        float velocityY = rb.linearVelocity.y;


        float angle = Mathf.Lerp(maxDownAngle, maxUpAngle, (velocityY + 5f) / 10f);


        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            Debug.Log("Score: " + GameManager.instance.score);
            GameManager.instance.AddScore();
            if (pointAudio != null)
            {
                pointAudio.Play();
            }
        }

        if(other.CompareTag("GroundTrigger"))
        {
            Debug.Log("Game Over");
            GameManager.instance.GameOver();
            isDead = true;
            if (gameOverAudio != null)
            {
                gameOverAudio.Play();
            }

        }
    }
}
