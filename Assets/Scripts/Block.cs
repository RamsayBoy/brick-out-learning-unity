using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.ToLower().Trim().Contains("ball"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
