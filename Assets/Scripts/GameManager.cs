using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
