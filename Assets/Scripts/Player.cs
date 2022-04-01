using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Ball _ball;

    private float _xMovementValue;
    [SerializeField] private float _speed;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _xMovementValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _ball.State == BallState.Holded)
        {
            _ball.StartRolling();
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + new Vector3(_xMovementValue, 0) * Time.deltaTime * _speed);
    }
}
