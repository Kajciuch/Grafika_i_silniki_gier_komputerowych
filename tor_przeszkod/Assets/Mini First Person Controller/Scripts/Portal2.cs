using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    [Tooltip("Nazwa sceny, kt�ra ma zosta� za�adowana po wej�ciu do portalu")]
    public string sceneToLoad = "lvl3";

    [Tooltip("Tag obiektu, kt�ry ma by� przenoszony (np. 'Player')")]
    public string requiredTag = "Player";

    private void Reset()
    {
        // pomocniczo: ustaw collider jako trigger je�li skrypt zosta� dodany przez pomy�k�
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
            Debug.LogWarning("Portal: scena do za�adowania nie jest ustawiona!");
            return;
        }

        // tutaj �adujemy scen�
        SceneManager.LoadScene(sceneToLoad);
    }
}
