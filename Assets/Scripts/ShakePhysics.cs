using UnityEngine;

public class ShakePhysics : MonoBehaviour
{
    public float forceMagnitude = 1f; // Intensité de l'impulsion

    public void ApplyShake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 randomForce = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(0.2f, 1f), // un peu vers le haut
                Random.Range(-1f, 1f)
            ) * forceMagnitude;

            rb.AddForce(randomForce, ForceMode.Impulse);
        }
    }
}
