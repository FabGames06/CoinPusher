using UnityEngine;

public class LightsManager : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public Light light3;
    public Light light4;

    public float blinkInterval = 0.5f; // Durée entre les clignotements en secondes
    private float timer = 0f;
    private bool isOn = true;

    void Start()
    {
        SetLights(isOn);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= blinkInterval)
        {
            isOn = !isOn;
            SetLights(isOn);
            timer = 0f;
        }
    }

    void SetLights(bool state)
    {
        light1.enabled = state;
        light2.enabled = !state;
        light3.enabled = state;
        light4.enabled = !state;
    }
}
