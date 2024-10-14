using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSScene : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private void Start()
    {
        UpdateScoreUI();
    }

    private void Update()
    {
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.UpdateScoreUI(scoreText);
        }
    }
}
