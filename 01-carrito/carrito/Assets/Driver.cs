using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float velocidadGiro = 85;
    [SerializeField] private float velocidadMovimiento = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float valorGiro = Input.GetAxis("Horizontal") * velocidadGiro * Time.deltaTime;
        float valorMovimiento = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;

        transform.Rotate(0, 0, -valorGiro);
        transform.Translate(0, valorMovimiento, 0);
    }
}
