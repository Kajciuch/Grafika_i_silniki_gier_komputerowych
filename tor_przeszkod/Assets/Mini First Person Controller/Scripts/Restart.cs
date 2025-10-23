using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [Tooltip("Y poni�ej kt�rego gra si� resetuje")]
    public float fallThreshold = -5f;

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Wczytuje scen� lvl1 (upewnij si�, �e istnieje w Build Settings)
        SceneManager.LoadScene("lvl1");
    }
}
