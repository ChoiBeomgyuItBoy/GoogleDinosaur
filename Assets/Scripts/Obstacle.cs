using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float screenEdgePosition;
    GameSettings settings;

    void Awake()
    {
        settings = FindObjectOfType<GameSettings>();
    }

    void Start()
    {
        screenEdgePosition = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2;
    }

    void Update()
    {
        if(transform.position.x < screenEdgePosition)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.left * settings.GetGameSpeed() * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        var controller = other.GetComponent<PlayerController>();

        if(controller != null)
        {
            controller.Kill(); 
        }
    }
}
