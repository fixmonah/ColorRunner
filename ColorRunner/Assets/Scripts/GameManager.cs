using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WayGenerator _wayGenerator;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerController _playerController;

    private Color _selectedColor = Color.black;
    private int _score;

    private void Start()
    {
        _wayGenerator.ActionColorSelected = ColorSelected;
        _wayGenerator.ActionPlayerTouchColorObject = PlayerTouchColorObject;
        GameStateStartGame();
    }

    public int GetPlayerLevel() { return _player.GetLevel(); }
    public int GetScore() { return _score; }

    public void GameStateStartGame()
    {
        _score = 0;
        _player.ResetLevel();
        _playerController.SetPause(false);
    }
    public void GameStateGameOver()
    {
        _playerController.SetPause(true);
        PlayerPrefs.SetInt("Score", _score);
        SceneManager.LoadScene("End");
    }

    private void ColorSelected(Color color) 
    {
        _selectedColor = color;
        _player.SetColor(color);
    }
    private void PlayerTouchColorObject(Color color)
    {
        if (_selectedColor == color)
        {
            _score++;
            _player.AddLevel();
        }
        else
        {
            _player.RemoveLevel();
        }
        CheckPlayerStatus();
    }

    private void CheckPlayerStatus()
    {
        if (_player.GetLevel() < 0)
        {
            GameStateGameOver();
        }
    }
}
