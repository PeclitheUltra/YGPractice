using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int Score { get; private set; }
    public Action Scored;
    [SerializeField] private GameObject _gameStartHint;
    [SerializeField] private PlayerMovement _movement;
    
    private IEnumerator Start()
    {
        _movement.enabled = false;
        while (!InputSystem.IsPressing)
            yield return null;
        _movement.enabled = true;
        _gameStartHint.SetActive(false);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore()
    {
        Score++;
        Scored?.Invoke();
    }
}
