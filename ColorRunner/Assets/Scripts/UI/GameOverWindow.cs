using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI _score;

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    void Update()
    {
        _score.text = string.Format($"Score {PlayerPrefs.GetInt("Score")}");
    }
}
