using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 12f; // Gaya pantul trampolin

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, bounceForce);
            }
        }
    }
}
