using UnityEngine;
using TMPro;

public class PointCollector : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    void Start()
    {
        score = 0; // Reset skor ke 0 setiap kali permainan dimulai
        PlayerPrefs.SetInt("SavedScore", 0); // Juga reset di PlayerPrefs
        UpdateScoreUI();
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Point"))
        {
            score += 1;
            Destroy(other.gameObject);
            UpdateScoreUI();
            PlayerPrefs.SetInt("SavedScore", score);
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Point: " + score;
        }
    }
}
