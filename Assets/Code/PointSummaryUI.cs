using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PointSummaryUI : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        Debug.Log("Score terbaca di PointSummary: " + score);
        scoreText.text = "Total Point: " + score;
    }

    public void OnNextButtonPressed()
    {
        int nextIndex = PlayerPrefs.GetInt("NextSceneIndex", -1);
        if (nextIndex >= 0 && nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            SceneManager.LoadScene("Level");
        }
    }
}
