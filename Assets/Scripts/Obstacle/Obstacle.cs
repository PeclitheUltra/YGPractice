using UnityEngine;
using UnityEngine.Pool;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private IObjectPool<Obstacle> _myPool;
    [SerializeField] private float _movementDelta;
    private float _randomTimeOffset, _startY;

    private void OnBecameInvisible()
    {
        Release();
    }

    public void Release()
    {
        if(gameObject.activeSelf)
            _myPool.Release(this);
    }

    private void OnEnable()
    {
        _startY = transform.position.y;
        _randomTimeOffset = Random.Range(0f, 360f);
    }

    private void Update()
    {
        var pos = transform.position;
        transform.position = new Vector3(pos.x, _startY + Mathf.Sin(Time.time + _randomTimeOffset) * _movementDelta, pos.z);
    }
    
    public Obstacle SetReferenceToAPool(IObjectPool<Obstacle> pool)
    {
        _myPool = pool;
        return this;
    }
}