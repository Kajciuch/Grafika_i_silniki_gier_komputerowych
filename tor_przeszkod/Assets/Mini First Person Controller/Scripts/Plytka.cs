using UnityEngine;

public class Plytka : MonoBehaviour
{
    [SerializeField] float strength = 10f; // moc odbicia (mo¿esz ustawiæ w Inspectorze)

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Najpierw wyczyœæ prêdkoœæ w pionie (¿eby nie "zjada³o" si³y)
            Vector3 vel = rb.velocity;
            vel.y = 0;
            rb.velocity = vel;

            // Teraz dodaj impuls w górê
            rb.AddForce(Vector3.up * strength, ForceMode.Impulse);

            Debug.Log("Plytka aktywowana! Si³a: " + strength);
        }
    }
}
