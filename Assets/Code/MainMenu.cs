using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("Level");
    }

    public void exit()
    {
        Application.Quit();
    }
}
