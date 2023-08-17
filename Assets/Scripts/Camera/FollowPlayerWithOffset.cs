using UnityEngine;

public class FollowPlayerWithOffset : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private float _offsetX;

    private void Start()
    {
        _offsetX = _playerTransform.position.x - transform.position.x;
    }

    private void LateUpdate()
    {
        var pos = transform.position;
        pos.x = _playerTransform.position.x - _offsetX;
        transform.position = pos;
    }
}
