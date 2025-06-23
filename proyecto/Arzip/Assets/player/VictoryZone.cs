using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.HasAllBlood())
        {
            Debug.Log("¡Victoria!");
            // Aquí puedes cargar escena de victoria, mostrar panel, etc.
        }
    }
}