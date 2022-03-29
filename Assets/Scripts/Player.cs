using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Start()
    {

    }

    void Update()
    {
        // Get user input
        float xVectorValue = Input.GetAxisRaw("Horizontal");

        // Move player depending on user input
        transform.Translate(_speed * Time.deltaTime * new Vector3(xVectorValue, 0));
    }
}
