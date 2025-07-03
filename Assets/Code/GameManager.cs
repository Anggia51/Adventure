using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerTransform;

    private void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Jika resume dari pause, kembalikan posisi
        if (PlayerPrefs.GetString("LastScene") == currentScene && PlayerPrefs.GetInt("HasSavedPosition", 0) == 1)
        {
            RestorePlayerPosition();
        }

        PlayerPrefs.SetString("LastScene", currentScene);
    }

    // Simpan posisi saat pause
    public void OnPauseOrExit()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
        PlayerPrefs.SetInt("HasSavedPosition", 1); // Flag: posisi sudah disimpan
        PlayerPrefs.Save();
    }

    // Kembalikan ke posisi terakhir
    private void RestorePlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX", playerTransform.position.x);
        float y = PlayerPrefs.GetFloat("PlayerY", playerTransform.position.y);
        float z = PlayerPrefs.GetFloat("PlayerZ", playerTransform.position.z);

        playerTransform.position = new Vector3(x, y, z);
        Debug.Log("Posisi player dipulihkan ke: " + playerTransform.position);
    }

    // Masuk ke opsi
    public void Options()
    {
        SceneManager.LoadSceneAsync("Options");
    }
}
