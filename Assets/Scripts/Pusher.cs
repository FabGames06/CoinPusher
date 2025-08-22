using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pusher : MonoBehaviour
{
    private float direction;
    private float speed;
    public float limitZMin = .5f;
    public float limitZMax = 1f;

    private Rigidbody rb;

    void Start()
    {
        direction = -1f;
        speed = .5f;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Important pour garder le contrôle manuel
    }

    void FixedUpdate()
    {
        Vector3 newPosition = rb.position + new Vector3(0, 0, direction * speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if (newPosition.z <= limitZMin || newPosition.z >= limitZMax)
            direction = -direction;
    }
}
