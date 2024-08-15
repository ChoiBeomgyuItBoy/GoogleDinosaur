using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Obstacle[] obstacles;
    [SerializeField] float minSpawnDelay = 1;
    [SerializeField] float maxSpawnDelay = 5;
    float timeSinceSpawned = Mathf.Infinity;
    float spawnDelay = 0;

    void Update()
    {
        timeSinceSpawned += Time.deltaTime;

        if(timeSinceSpawned > spawnDelay)
        {
            timeSinceSpawned = 0;

            spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

            print(spawnDelay);

            int randomIndex = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
