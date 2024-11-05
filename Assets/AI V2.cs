using UnityEngine;

public class MovingDummy : MonoBehaviour
{
    public float speed = 2f; // Movement speed
    public float changeDirectionInterval = 3f; // Time in seconds to change direction
    public Vector3 movementBounds = new Vector3(10f, 0, 10f); // Bounds for movement area

    private Animator animator;
    private Vector3 direction;
    private float timer;

    void Start()
    {
        // Set up the Animator component
        animator = GetComponent<Animator>();

        // Set an initial random direction
        ChangeDirection();
    }

    void Update()
    {
        // Move the dummy
        transform.Translate(direction * speed * Time.deltaTime);

        // Update the timer and change direction if the interval is reached
        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            ChangeDirection();
            timer = 0;
        }

        // Check boundaries and reverse direction if necessary
        CheckBounds();

        // Update animation based on movement
        if (direction.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void ChangeDirection()
    {
        // Choose a new random direction
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    void CheckBounds()
    {
        Vector3 pos = transform.position;

        // Reverse direction if the dummy hits the boundary
        if (pos.x > movementBounds.x || pos.x < -movementBounds.x)
            direction.x = -direction.x;

        if (pos.z > movementBounds.z || pos.z < -movementBounds.z)
            direction.z = -direction.z;
    }
}

