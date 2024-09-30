using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text scoreText;

    int lives = 3;
    int score;

    public static GameManager instance;

    [SerializeField] AudioClip failSound;
    [SerializeField] GameObject gameOverScreen;

    void Start()
    {
        instance = this;
    }

    public void AddScore(int value = 1)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void Damage(int value = 1)
    {
        lives -= value;
        if (lives <= 0) GameOver();
        livesText.text = lives + " lives";
        Audio.Play(failSound);
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}