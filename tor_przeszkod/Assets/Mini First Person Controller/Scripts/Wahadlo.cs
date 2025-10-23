using UnityEngine;

public class Wahadlo : MonoBehaviour
{
    [SerializeField] float amplitude = 45f;   // maksymalny k�t odchylenia w stopniach
    [SerializeField] float speed = 2f;        // pr�dko�� bujania

    private float startZ;

    void Start()
    {
        startZ = transform.localEulerAngles.z; // zapami�tujemy pocz�tkowy k�t
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * amplitude;
        transform.localRotation = Quaternion.Euler(0, 0, startZ + angle);
    }
}
