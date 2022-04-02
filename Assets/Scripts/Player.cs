using UnityEngine;

public class Player : MonoBehaviour
{
    public const float LEFT_RAYCAST_DISTANCE = 0.8f;
    public const float RIGHT_RAYCAST_DISTANCE = 0.8f;

    [SerializeField] private Ball _ball;

    [SerializeField] private float _speed;
    private RaycastHit2D _leftRaycastHit;
    private RaycastHit2D _rightRaycastHit;

    void Update()
    {
        _leftRaycastHit = Physics2D.Raycast(transform.position, Vector2.left, LEFT_RAYCAST_DISTANCE);
        _rightRaycastHit = Physics2D.Raycast(transform.position, Vector2.right, RIGHT_RAYCAST_DISTANCE);

        Debug.DrawRay(transform.position, Vector2.left * LEFT_RAYCAST_DISTANCE, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * RIGHT_RAYCAST_DISTANCE, Color.red);

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

        // float distance = 0.05f;
        // Vector2 startPoint = new Vector2(transform.position.x - 0.751f, transform.position.y);
        // RaycastHit2D hit = Physics2D.Raycast(startPoint, Vector2.left, distance);
        // Debug.DrawRay(startPoint, Vector2.left * distance, Color.red);

        // float xMovement = Input.GetAxisRaw("Horizontal");

        // if (xMovement < 0 && hit.collider == null)
        // {
        //     Debug.Log("No ha chocado");
        //     transform.Translate(new Vector3(xMovement, 0) * Time.deltaTime * _speed);
        // }

        if (Input.GetKeyDown(KeyCode.Space) && _ball.State == BallState.Holded)
        {
            _ball.StartRolling();
        }
    }
}
