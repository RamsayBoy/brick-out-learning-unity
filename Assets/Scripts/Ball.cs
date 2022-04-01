using UnityEngine;

public enum BallState { Holded, Rolling }

public class Ball : MonoBehaviour
{
    public BallState State { get; set; }
    public Vector2 Direction { get; set; }
    public float Speed { get => _speed; set => Speed = value; }

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _player;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        State = BallState.Holded;
        Direction = Vector2.up;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (State == BallState.Holded)
        {
            var playerPosition = _player.transform.position;
            _rigidbody.position = new Vector2(playerPosition.x, playerPosition.y + 0.5f);
            return;
        }
    }

    public void StartRolling()
    {
        State = BallState.Rolling;
        _rigidbody.AddForce(Speed * Direction);
    }
}
