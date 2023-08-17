using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private ObstaclePool _obstaclePool;
    [SerializeField] private ScorePool _scorePool;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private float _playerOffset, _firstObstaclesDistance, _obstacleDistance;
    [SerializeField] private Vector2 _randomX, _randomY;
    [SerializeField] private Vector2Int _obstacleCount;
    private float _currentThreshold;

    private void Start()
    {
        _currentThreshold = _firstObstaclesDistance;
    }

    private void Update()
    {
        if (_player.transform.position.x + _playerOffset> _currentThreshold)
        {
            var obstacleCount = Random.Range(_obstacleCount.x, _obstacleCount.y);
            for (int i = 0; i < obstacleCount; i++)
            {
                var obstacle = _obstaclePool.Get();
                obstacle.transform.position = GetRandomPos();
            }
            var score = _scorePool.Get();
            score.transform.position =  GetRandomPos();
            _currentThreshold += _obstacleDistance;
        }
    }

    private Vector3 GetRandomPos()
    {
        return new Vector3(_currentThreshold + Random.Range(_randomX.x, _randomX.y), Random.Range(_randomY.x, _randomY.y), 0);
    }
}
