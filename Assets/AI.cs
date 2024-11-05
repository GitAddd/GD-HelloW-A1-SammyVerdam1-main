using UnityEngine;

public class RandomMovingNPC3D : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the NPC
    public float changeDirectionInterval = 2f; // Interval in seconds to change direction
    public Vector3 movementBounds = new Vector3(10f, 5f, 10f); // Movement boundaries in 3D space

    private Vector3 direction; // Current movement direction
    private float timer;

    void Start()
    {
        // Set an initial random direction
        ChangeDirection();
    }

    void Update()
    {
        // Move the NPC in the current direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Timer to change direction at intervals
        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            ChangeDirection();
            timer = 0;
        }

        // Check boundaries and reverse direction if NPC hits the edge
        CheckBounds();
    }

    void ChangeDirection()
    {
        // Set a random direction
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void CheckBounds()
    {
        Vector3 pos = transform.position;

        // Reverse direction if NPC hits the boundary on any axis
        if (pos.x > movementBounds.x || pos.x < -movementBounds.x)
            direction.x = -direction.x;

        if (pos.y > movementBounds.y || pos.y < -movementBounds.y)
            direction.y = -direction.y;

        if (pos.z > movementBounds.z || pos.z < -movementBounds.z)
            direction.z = -direction.z;
    }
}
