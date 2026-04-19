using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
