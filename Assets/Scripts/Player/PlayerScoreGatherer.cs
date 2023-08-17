using UnityEngine;

public class PlayerScoreGatherer : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _distance, _suckInPower, _maxSpeed, _collectDistance;
    private Collider2D[] _contacts = new Collider2D[1];
    
    private void FixedUpdate()
    {
        var transform1 = transform;
        var contanctCount = Physics2D.OverlapCircleNonAlloc(transform1.position, _distance,
            _contacts, _mask);

        if (contanctCount > 0)
        {
            var diffVector = transform.position - _contacts[0].transform.position;
            var diffVectorMagnitude = diffVector.magnitude;
            if (diffVectorMagnitude < _collectDistance)
            {
                _contacts[0].GetComponent<Score>().Release();
                _game.AddScore();
            }
            else
            {
                Vector3 move = (diffVector).normalized / diffVectorMagnitude * (Time.fixedDeltaTime * _suckInPower);
                move = Vector3.ClampMagnitude(move, _maxSpeed);
                _contacts[0].transform.position += move;
            }
            
        }
    }
}
