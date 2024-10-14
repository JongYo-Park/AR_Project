using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] private AudioClip sceneBGM;

    private void Start()
    {
        SoundManager.Instance.PlayBGM(sceneBGM);
    }
}
