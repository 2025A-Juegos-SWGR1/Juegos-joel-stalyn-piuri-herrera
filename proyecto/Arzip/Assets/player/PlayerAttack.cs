using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float attackRange = 2f;

    void Update()
    {
        Vector2 direction = Vector2.right; // ajustable
        Vector2 origin = (Vector2)transform.position + direction * 0.5f; // << desplazamos origen

        // Dibuja en escena
        Debug.DrawRay(origin, direction * attackRange, Color.red);

        if (Input.GetKeyDown(attackKey))
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, attackRange);

            if (hit.collider != null)
            {
                Debug.Log("Impacto con: " + hit.collider.name);

                if (hit.collider.CompareTag("Vampiro"))
                {
                    hit.collider.GetComponent<EnemyVampire>()?.TakeHit();
                }
            }
            else
            {
                Debug.Log("No impactó a nada");
            }
        }
    }
}