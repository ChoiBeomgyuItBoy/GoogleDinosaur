using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Scorer scorer;

    void OnEnable()
    {
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        restartButton.onClick.AddListener(Restart);
    }

    void Restart()
    {
        scorer.SaveHighScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
