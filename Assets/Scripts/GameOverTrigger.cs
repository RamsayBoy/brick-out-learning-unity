using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.ToLower().Trim().Contains("ball"))
        {
            _gameManager.ResetGame();
        }
    }
}
