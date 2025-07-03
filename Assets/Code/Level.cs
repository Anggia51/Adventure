using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void Level1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadSceneAsync("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadSceneAsync("Level4");
    }
    public void Level5()
    {
        SceneManager.LoadSceneAsync("Level5");
    }
    public void Level6()
    {
        SceneManager.LoadSceneAsync("Level6");
    }
}
