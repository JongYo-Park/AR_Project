using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text bestScoreText;

    private void Start()
    {
        UpdateScoreUI();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            ScoreManager.Instance.ResetScore();
            SceneManager.LoadScene("StartScene");
        }
    }
    private void UpdateScoreUI()
    {
        if (ScoreManager.Instance != null)
        {
            scoreText.text = "Score: " + ScoreManager.Instance.score;
            bestScoreText.text = "Best Score: " + ScoreManager.Instance.bestScore;
        }
    }
}
