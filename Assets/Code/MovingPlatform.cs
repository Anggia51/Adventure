using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;              // Kecepatan platform
    public float minX = 0.7f;             // Batas kiri
    public float maxX = 11.35f;           // Batas kanan

    private bool movingRight = true;

    void Update()
    {
        Vector3 pos = transform.position;

        if (movingRight)
        {
            pos.x += speed * Time.deltaTime;
            if (pos.x >= maxX)
            {
                pos.x = maxX;
                movingRight = false;
            }
        }
        else
        {
            pos.x -= speed * Time.deltaTime;
            if (pos.x <= minX)
            {
                pos.x = minX;
                movingRight = true;
            }
        }

        transform.position = pos;
    }
}
