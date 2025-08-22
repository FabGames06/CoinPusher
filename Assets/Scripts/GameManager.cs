using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textToken;
    public int nbTokens;

    void Start()
    {
        nbTokens = 0;
        RefreshTokens();
    }

    void Update()
    {
        
    }

    public void RefreshTokens()
    {
        textToken.text = nbTokens.ToString();
    }
}
