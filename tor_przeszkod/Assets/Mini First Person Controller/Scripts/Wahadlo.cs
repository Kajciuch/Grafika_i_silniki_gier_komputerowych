using UnityEngine;

public class Wahadlo : MonoBehaviour
{
    [SerializeField] float amplitude = 45f;   // maksymalny k¹t odchylenia w stopniach
    [SerializeField] float speed = 2f;        // prêdkoœæ bujania

    private float startZ;

    void Start()
    {
        startZ = transform.localEulerAngles.z; // zapamiêtujemy pocz¹tkowy k¹t
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * amplitude;
        transform.localRotation = Quaternion.Euler(0, 0, startZ + angle);
    }
}
