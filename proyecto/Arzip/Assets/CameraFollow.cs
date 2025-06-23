using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        Camera cam = Camera.main;
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;

        // Buscar el objeto con SpriteRenderer que representa el mapa
        SpriteRenderer mapRenderer = GameObject.Find("MapaFondo")?.GetComponent<SpriteRenderer>();

        if (mapRenderer != null)
        {
            Vector3 size = mapRenderer.bounds.size;
            Vector3 center = mapRenderer.bounds.center;

            // Calcular los extremos del sprite
            minBounds = new Vector2(center.x - size.x / 2, center.y - size.y / 2);
            maxBounds = new Vector2(center.x + size.x / 2, center.y + size.y / 2);
        }
        else
        {
            Debug.LogWarning("No se encontró un SpriteRenderer llamado 'MapaFondo'");
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            float clampedX = Mathf.Clamp(target.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(target.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

            transform.position = new Vector3(clampedX, clampedY, -10f);
        }
    }
}