using UnityEngine;
using UnityEngine.SceneManagement; // para recargar o terminar el juego

public class EnemyFollow : MonoBehaviour
{
    public Transform target; // jugador
    public float speed = 2f;

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El enemigo atrapó al jugador! Fin del juego.");
            // Aquí puedes hacer una animación o transicionar a otra escena
            // Por ahora, solo detener el juego
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}