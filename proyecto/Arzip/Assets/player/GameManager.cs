using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Para TextMeshProUGUI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int bloodCount = 0;
    public int requiredBlood = 5;

    public TextMeshProUGUI textoGotas;      // Texto en pantalla (UI)
    public GameObject victoryPanel;         // Panel que muestra "¡Has ganado!"

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas si es necesario
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddBlood()
    {
        bloodCount++;
        Debug.Log("Gotas recogidas: " + bloodCount);
        UpdateUI();
    }

    public bool HasAllBlood()
    {
        return bloodCount >= requiredBlood;
    }

    void UpdateUI()
    {
        if (textoGotas != null)
        {
            textoGotas.text = "Gotas: " + bloodCount + " / " + requiredBlood;
        }
    }

    public void ShowVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f; // Detiene el tiempo del juego
        }
        else
        {
            Debug.LogWarning("VictoryPanel no está asignado en el GameManager.");
        }
    }
}