using UnityEngine;
using UnityEngine.Pool;

public class ScorePool : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private int _defaultSize, _maxSize;
    private IObjectPool<Score> _scorePool;

    private void Start()
    {
        _scorePool = new ObjectPool<Score>(InstantiateScore, OnGetFromPool, OnReturnToPool, null, true, _defaultSize, _maxSize);
    }

    public Score Get()
    {
        return _scorePool.Get();
    }
    
    private Score InstantiateScore()
    {
        return Instantiate(_score).SetReferenceToAPool(_scorePool);
    }

    private void OnGetFromPool(Score score)
    {
        score.gameObject.SetActive(true);
    }

    private void OnReturnToPool(Score score)
    {
        score.gameObject.SetActive(false);
    }
}
