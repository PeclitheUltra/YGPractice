using System;
using UnityEngine;
using UnityEngine.Pool;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private int _defaultSize, _maxSize;
    private IObjectPool<Obstacle> _obstaclePool;

    private void Start()
    {
        _obstaclePool = new ObjectPool<Obstacle>(InstantiateObstacle, OnGetFromPool, OnReturnToPool, null, true, _defaultSize, _maxSize);
    }

    public Obstacle Get()
    {
        return _obstaclePool.Get();
    }
    
    private Obstacle InstantiateObstacle()
    {
        return Instantiate(_obstaclePrefab).SetReferenceToAPool(_obstaclePool);
    }

    private void OnGetFromPool(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(true);
    }

    private void OnReturnToPool(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
    }
}
