using UnityEngine;

public enum BallState { Holded, Rolling }

public class Ball : MonoBehaviour
{
    public BallState State { get; set; }
    public Vector2 Direction { get; set; }
    public float Speed { get => _speed; set => _speed = value; }

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _player;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SetInitialValues();
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

    public void SetInitialValues()
    {
        _rigidbody.velocity = Vector2.zero;
        Direction = Vector2.up;
        State = BallState.Holded;
    }
}
