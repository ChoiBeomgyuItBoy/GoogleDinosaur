using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] float initialSpeed = 1;
    [SerializeField] float speedMultiplier = 0.3f;
    float currentSpeed = 0;

    public float GetGameSpeed()
    {
        return currentSpeed;
    }

    void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        currentSpeed += speedMultiplier * Time.deltaTime;
    }
}
