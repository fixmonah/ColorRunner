using UnityEngine;

public class GameWindow : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] TMPro.TextMeshProUGUI _score;
    [SerializeField] TMPro.TextMeshProUGUI _level;

    void Update()
    {
        _score.text = string.Format($"Score {_gameManager.GetScore()}");
        _level.text = string.Format($"Level {_gameManager.GetPlayerLevel()}");
    }
}
