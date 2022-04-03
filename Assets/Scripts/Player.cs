using UnityEngine;

public class Player : MonoBehaviour
{
    public const float LEFT_RAYCAST_DISTANCE = 0.8f;
    public const float RIGHT_RAYCAST_DISTANCE = 0.8f;

    public float StartYPosition { get; set; }   // To know the start player y position

    [SerializeField] private Ball _ball;
    [SerializeField] private float _speed;
    private RaycastHit2D _leftRaycastHit;
    private RaycastHit2D _rightRaycastHit;

    void Start()
    {
        StartYPosition = transform.position.y;
    }

    void Update()
    {
        _leftRaycastHit = Physics2D.Raycast(transform.position, Vector2.left, LEFT_RAYCAST_DISTANCE);
        _rightRaycastHit = Physics2D.Raycast(transform.position, Vector2.right, RIGHT_RAYCAST_DISTANCE);

        float xMovement = Input.GetAxisRaw("Horizontal");

        if (_leftRaycastHit.collider != null && xMovement < 0)
        {
            xMovement = 0;
        }

        if (_rightRaycastHit.collider != null && xMovement > 0)
        {
            xMovement = 0;
        }

        transform.Translate(new Vector3(xMovement, 0) * Time.deltaTime * _speed);

        if (Input.GetKeyDown(KeyCode.Space) && _ball.State == BallState.Holded)
        {
            _ball.StartRolling();
        }
    }

    public void SetInitialValues()
    {
        transform.position = new Vector3(0, StartYPosition);
    }
}
