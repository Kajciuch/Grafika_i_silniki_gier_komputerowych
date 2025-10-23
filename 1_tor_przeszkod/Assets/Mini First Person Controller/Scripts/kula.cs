using UnityEngine;

public class kula : MonoBehaviour
{
    [SerializeField] private float strength = 10f; // jak mocno wybija w g�r�

    private void OnTriggerEnter(Collider other)
    {
        // Szukamy Rigidbody na obiekcie, kt�ry dotkn�� kuli
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null && rb.gameObject != gameObject)
        {
            // Zerujemy pionow� pr�dko��, �eby impuls by� zawsze taki sam
            Vector3 vel = rb.velocity;
            vel.y = 0f;
            rb.velocity = vel;

            // Dodajemy impuls w g�r�
            rb.AddForce(Vector3.up * strength, ForceMode.Impulse);

            Debug.Log($"{gameObject.name} odbi�a obiekt: {other.name} si�� {strength}");
        }
    }
}
