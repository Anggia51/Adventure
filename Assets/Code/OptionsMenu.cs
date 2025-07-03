using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    // Resume: kembali ke scene terakhir dengan posisi tersimpan
    public void OnResumeButtonPressed()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "");
        if (!string.IsNullOrEmpty(lastScene))
        {
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.LogWarning("Belum ada scene yang disimpan.");
        }
    }

    // Quit: hapus semua data posisi → kembali ke posisi awal
    public void Home()
    {
        PlayerPrefs.DeleteKey("PlayerX");
        PlayerPrefs.DeleteKey("PlayerY");
        PlayerPrefs.DeleteKey("PlayerZ");
        PlayerPrefs.DeleteKey("HasSavedPosition");
        PlayerPrefs.DeleteKey("LastScene");
        PlayerPrefs.Save();

        SceneManager.LoadSceneAsync("SampleScene");
    }
}
