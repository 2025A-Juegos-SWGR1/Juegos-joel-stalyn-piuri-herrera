using UnityEngine;

public class BloodCollect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddBlood(); // actualizar contador
            Destroy(gameObject);
        }
    }
}