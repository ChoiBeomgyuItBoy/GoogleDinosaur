using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Scorer scorer;

    void Update()
    {
        int currentScore = Mathf.FloorToInt(scorer.GetCurrentScore());
        int highScore = Mathf.FloorToInt(scorer.GetHighScore());

        scoreText.text = $"HI {highScore:D5} {currentScore:D5}";
    }
}
