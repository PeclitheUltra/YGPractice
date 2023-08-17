using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed, _flyPower, _gravity, _rotationDrag, _rotationAcceleration, _maxRotationSpeed;
    [SerializeField] private Vector2 _verticalSpeedBounds;
    private float _verticalSpeed, _rotationSpeed;


    private void FixedUpdate()
    {
        if (InputSystem.IsPressing)
        {
            _verticalSpeed += _flyPower * Time.fixedDeltaTime;
            _rotationSpeed += _rotationAcceleration * Time.fixedDeltaTime;
        }
        else
        {
            _verticalSpeed += _gravity * Time.fixedDeltaTime;
            _rotationSpeed += _rotationDrag * Time.fixedDeltaTime;
        }

        _verticalSpeed = Mathf.Clamp(_verticalSpeed, _verticalSpeedBounds.x, _verticalSpeedBounds.y);
        _rotationSpeed = Mathf.Clamp(_rotationSpeed, 0, _maxRotationSpeed);
        transform.position += Vector3.up * (_verticalSpeed * Time.fixedDeltaTime) + Vector3.right * (_horizontalSpeed * Time.fixedDeltaTime);
        transform.rotation *= Quaternion.Euler(0, 0, _rotationSpeed * Time.fixedDeltaTime);
    }
}
