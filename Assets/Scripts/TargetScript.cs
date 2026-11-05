using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 4f;
    [SerializeField] private float maxForce = 3f;

    [Header("Random movement")]
    [SerializeField] private float areaWidth = 15f;
    [SerializeField] private float areaHeight = 8f;
    [SerializeField] private float targetRadius = 1f;

    // El BehaviourScript necesita acceder a esta velocidad
    public Vector3 velocity;

    private Vector3 randomTarget;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        ChooseNewTarget();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, randomTarget) < targetRadius)
        {
            ChooseNewTarget();
        }

        Vector3 desired =
            (randomTarget - transform.position).normalized * speed;

        Vector3 steering = desired - velocity;

        steering = Vector3.ClampMagnitude(steering, maxForce);

        velocity += steering * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, speed);

        transform.position += velocity * Time.deltaTime;

        if (velocity != Vector3.zero)
        {
            transform.up = velocity;
        }

        Debug.DrawLine(
            transform.position,
            randomTarget,
            Color.yellow
        );

        Debug.DrawLine(
            transform.position,
            transform.position + velocity,
            Color.green
        );
    }

    void ChooseNewTarget()
    {
        float x = Random.Range(-areaWidth / 2f, areaWidth / 2f);
        float y = Random.Range(-areaHeight / 2f, areaHeight / 2f);

        randomTarget =
            startPosition + new Vector3(x, y, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector3 center =
            Application.isPlaying
                ? startPosition
                : transform.position;

        Gizmos.DrawWireCube(
            center,
            new Vector3(areaWidth, areaHeight, 0)
        );
    }
}