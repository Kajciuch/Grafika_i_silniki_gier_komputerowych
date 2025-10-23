using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // potrzebne do zmiany sceny

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] string nextSceneName = "lvl2"; // nazwa sceny, do której przenosi portal
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Ruch postaci
        IsRunning = canRun && Input.GetKey(runningKey);
        float targetMovingSpeed = IsRunning ? runSpeed : speed;

        if (speedOverrides.Count > 0)
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();

        Vector2 targetVelocity = new Vector2(
            Input.GetAxis("Horizontal") * targetMovingSpeed,
            Input.GetAxis("Vertical") * targetMovingSpeed
        );

        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }

    // WYKRYWANIE PORTALU
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dotknięto obiektu: " + other.gameObject.name); // podgląd w konsoli

        if (other.CompareTag("Portal")) // sprawdza czy obiekt ma tag "Portal"
        {
            Debug.Log("Wchodzę do portalu! Ładuję scenę: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
