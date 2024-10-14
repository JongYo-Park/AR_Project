using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float curTime;
    [SerializeField] private UnityEngine.UI.Text text;

    int minute;
    int second;

    private void Awake()
    {
        time = 10;
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        curTime = time;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            text.text = minute.ToString("00") + ":" + second.ToString("00");

            if (curTime <= 10)
            {
                text.color = Color.red;
            }
            else
            {
                text.color = Color.white; // 기본 색상으로 되돌리기
            }

            yield return null;
        }

        curTime = 0;
        SceneManager.LoadScene("EndScene");
    }
}
