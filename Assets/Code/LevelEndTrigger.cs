using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PointCollector pointCollector = other.GetComponent<PointCollector>();
            if (pointCollector != null)
            {
                int finalScore = pointCollector.score;
                PlayerPrefs.SetInt("Score", finalScore);
                Debug.Log("Skor disimpan: " + finalScore);
            }
            else
            {
                Debug.LogWarning("Player tidak memiliki PointCollector!");
                PlayerPrefs.SetInt("Score", 0);
            }

            int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("NextSceneIndex", nextIndex);

            SceneManager.LoadScene("PointSummary");
        }
    }
}
