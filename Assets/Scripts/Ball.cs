using UnityEngine;

public enum BallState { Holded, Rolling }

public class Ball : MonoBehaviour
{
    public BallState State { get; set; }
    public Vector2 Direction { get; set; }
    public float Speed { get => _speed; set => Speed = value; }

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _player;

    void Start()
    {
        State = BallState.Holded;
        Direction = new Vector2(1, 0);
    }

    void Update()
    {
        if (State == BallState.Holded)
        {
            var playerPosition = _player.transform.position;
            transform.position = new Vector2(playerPosition.x, playerPosition.y + 0.5f);
            return;
        }

        if (State == BallState.Rolling)
        {
            // Make ball rolling
            transform.Translate(Speed * Time.deltaTime * Direction);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO
    }
}
