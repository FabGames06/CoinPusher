using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float duration = 0.3f;      // Durée du tremblement
    public float magnitude = 0.1f;     // Intensité du tremblement

    private Vector3 originalPos;
    private float elapsed = 0f;
    private bool isShaking = false;

    public void TriggerShake()
    {
        // utilisation du shake si minimum 10 coins
        GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (gm.nbTokens >= 10)
        {
            if (!isShaking)
            {
                originalPos = transform.localPosition;
                elapsed = 0f;
                isShaking = true;
            }

            foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Coin"))
            {
                piece.GetComponent<ShakePhysics>().ApplyShake();
            }

            gm.nbTokens -= 20;
            gm.RefreshTokens();
        }
    }

    void Update()
    {
        if (isShaking)
        {
            if (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = originalPos + new Vector3(x, y, 0f);
                elapsed += Time.deltaTime;
            }
            else
            {
                transform.localPosition = originalPos;
                isShaking = false;
            }
        }
    }
}
