using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1f;
    public float heightOffset = 2f;

    private float timer = 0f;
    private bool gameOver = false;

    void Update()
    {
        if (gameOver) return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipePrefab,
            new Vector3(transform.position.x + 4f, Random.Range(lowestPoint, highestPoint), 0),
            Quaternion.identity);
    }

    public void StopSpawning()
    {
        gameOver = true;
    }
}
