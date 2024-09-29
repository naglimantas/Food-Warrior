using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text livesText; // ne public o sreialize field kad "hackeriai" nepridarytu gyvybiu
    [SerializeField] TMP_Text scoreText;

    int lives;
    int score;

    public static GameManager instance;

    [SerializeField] AudioClip failSound;
    [SerializeField] GameObject gameOverScreen;

    private void Start()
    {
        instance = this;
    }

    public void Addscore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void Damage(int value=1)
    {
        lives-=value;
        if (lives <= 0) GameOver();
        livesText.text = lives + "lives";
        Audio.Play(failSound);
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
