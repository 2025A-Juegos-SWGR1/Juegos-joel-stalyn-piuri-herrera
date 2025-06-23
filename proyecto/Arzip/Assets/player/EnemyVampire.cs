using UnityEngine;

public class EnemyVampire : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float stunDuration = 10f;
    public GameObject bloodDropPrefab;
    public Transform target;

    private int hitCount = 0;
    private bool isStunned = false;
    private float currentSpeed;

    void Start()
    {
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        if (!isStunned && target != null)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            transform.position += (Vector3)dir * currentSpeed * Time.deltaTime;
        }
    }

    public void TakeHit()
    {
        hitCount++;

        if (hitCount % 3 == 0)
        {
            DropBlood();
            StartCoroutine(Stun());
            currentSpeed += 0.5f; // aumenta dificultad
        }
    }

    void DropBlood()
    {
        Vector3 dropPosition = transform.position + new Vector3(0, -0.5f, 0); // media unidad abajo
        Instantiate(bloodDropPrefab, dropPosition, Quaternion.identity);
    }


    System.Collections.IEnumerator Stun()
    {
        isStunned = true;
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }
}