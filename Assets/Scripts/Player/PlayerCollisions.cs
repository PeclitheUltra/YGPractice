using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private LayerMask _mask;
    private Collider2D[] _contacts = new Collider2D[1];
    
    private void FixedUpdate()
    {
        var transform1 = transform;
        var contanctCount = Physics2D.OverlapBoxNonAlloc(transform1.position, Vector3.one, transform1.rotation.eulerAngles.z,
            _contacts, _mask);
        
        if(contanctCount > 0)
            _game.RestartScene();
    }
}
