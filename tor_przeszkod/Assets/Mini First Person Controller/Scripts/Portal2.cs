using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    [Tooltip("Nazwa sceny, która ma zostaæ za³adowana po wejœciu do portalu")]
    public string sceneToLoad = "lvl3";

    [Tooltip("Tag obiektu, który ma byæ przenoszony (np. 'Player')")]
    public string requiredTag = "Player";

    private void Reset()
    {
        // pomocniczo: ustaw collider jako trigger jeœli skrypt zosta³ dodany przez pomy³kê
        Collider col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Portal: OnTriggerEnter z obiektem {other.gameObject.name}, tag: {other.tag}");
        if (!string.IsNullOrEmpty(requiredTag))
        {
            if (!other.CompareTag(requiredTag)) return;
        }

        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogWarning("Portal: scena do za³adowania nie jest ustawiona!");
            return;
        }

        // tutaj ³adujemy scenê
        SceneManager.LoadScene(sceneToLoad);
    }
}
