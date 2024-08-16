using UnityEngine;

public class Scorer : MonoBehaviour
{
    GameSettings settings;
    float highScore = 0;
    float currentScore = 0;

    public float GetHighScore()
    {
        if(highScore == 0)
        {
            highScore = PlayerPrefs.GetFloat("highScore");
        }

        return highScore;
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }

    public void SaveHighScore()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
        }

        PlayerPrefs.SetFloat("highScore", highScore);
    }

    void Awake()
    {
        settings = FindObjectOfType<GameSettings>();
    }

    void Update()
    {   
        currentScore += settings.GetGameSpeed() * Time.deltaTime;
    }
}
