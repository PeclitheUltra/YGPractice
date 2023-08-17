using UnityEngine;
using UnityEngine.Pool;

public class Score : MonoBehaviour
{
    private IObjectPool<Score> _myPool;

    private void OnBecameInvisible()
    {
        Release();
    }

    public Score SetReferenceToAPool(IObjectPool<Score> scorePool)
    {
        _myPool = scorePool;
        return this;
    }

    public void Release()
    {
        if(gameObject.activeSelf)
            _myPool.Release(this);
    }
}
