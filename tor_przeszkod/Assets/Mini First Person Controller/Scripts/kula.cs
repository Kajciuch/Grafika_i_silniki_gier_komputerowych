using UnityEngine;

public class kula : MonoBehaviour
{
    [SerializeField] private float strength = 10f; // jak mocno wybija w górê

    private void OnTriggerEnter(Collider other)
    {
        // Szukamy Rigidbody na obiekcie, który dotkn¹³ kuli
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null && rb.gameObject != gameObject)
        {
            // Zerujemy pionow¹ prêdkoœæ, ¿eby impuls by³ zawsze taki sam
            Vector3 vel = rb.velocity;
            vel.y = 0f;
            rb.velocity = vel;

            // Dodajemy impuls w górê
            rb.AddForce(Vector3.up * strength, ForceMode.Impulse);

            Debug.Log($"{gameObject.name} odbi³a obiekt: {other.name} si³¹ {strength}");
        }
    }
}
