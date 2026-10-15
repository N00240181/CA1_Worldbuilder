using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float height = 3f;
    public float speed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, height);

        transform.position = startPosition + Vector3.up * movement;
    }
}
