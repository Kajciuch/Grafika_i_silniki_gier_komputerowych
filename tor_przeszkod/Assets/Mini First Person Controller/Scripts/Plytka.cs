using UnityEngine;

public class Plytka : MonoBehaviour
{
    [SerializeField] float strength = 10f; // moc odbicia (mo�esz ustawi� w Inspectorze)

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Najpierw wyczy�� pr�dko�� w pionie (�eby nie "zjada�o" si�y)
            Vector3 vel = rb.velocity;
            vel.y = 0;
            rb.velocity = vel;

            // Teraz dodaj impuls w g�r�
            rb.AddForce(Vector3.up * strength, ForceMode.Impulse);

            Debug.Log("Plytka aktywowana! Si�a: " + strength);
        }
    }
}
