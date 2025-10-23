using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [Tooltip("Y poni¿ej którego gra siê resetuje")]
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
        // Wczytuje scenê lvl1 (upewnij siê, ¿e istnieje w Build Settings)
        SceneManager.LoadScene("lvl1");
    }
}
