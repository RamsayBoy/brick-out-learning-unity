using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float _xMovementValue;
    [SerializeField] private float _speed;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get user input for horizontal movement
        _xMovementValue = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Move player depending on user input (fixed update because a rigidbody is use)
        _rigidbody2D.MovePosition(transform.position + new Vector3(_xMovementValue, 0) * Time.deltaTime * _speed);
    }
}
