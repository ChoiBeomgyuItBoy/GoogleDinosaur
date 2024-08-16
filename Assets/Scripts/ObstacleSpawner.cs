using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] ObstacleConfig[] obstaclesConfig;
    [SerializeField] float minSpawnDelay = 1;
    [SerializeField] float maxSpawnDelay = 5;
    float timeSinceSpawned = Mathf.Infinity;
    float spawnDelay = 0;

    [System.Serializable]
    struct ObstacleConfig
    {
        public Obstacle obstacle;
        public float heightOffset;
    }

    void Update()
    {
        timeSinceSpawned += Time.deltaTime;

        if(timeSinceSpawned > spawnDelay)
        {
            timeSinceSpawned = 0;

            spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

            int randomIndex = Random.Range(0, obstaclesConfig.Length);

            Obstacle obstacle = obstaclesConfig[randomIndex].obstacle;

            float heightOffset = obstaclesConfig[randomIndex].heightOffset;

            Instantiate(obstacle, transform.position + Vector3.up * heightOffset, Quaternion.identity);
        }
    }
}
