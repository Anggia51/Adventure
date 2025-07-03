using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 respawnPoint;

    void Start()
    {
        respawnPoint = transform.position; // posisi awal
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform.position;
            Debug.Log("Checkpoint Tersimpan: " + respawnPoint);
        }

        if (other.CompareTag("Trap"))
        {
            transform.position = respawnPoint;
            Debug.Log("Respawn ke checkpoint");
        }
    }
}
