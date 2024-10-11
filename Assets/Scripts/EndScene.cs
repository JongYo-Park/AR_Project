using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
    private void EndGame()
    {
        scoreManager.SetBestScore();
    }
}
