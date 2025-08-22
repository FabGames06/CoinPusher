using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textToken;
    public int nbTokens;
    public TextMeshProUGUI textPoints;
    public int nbChips;

    void Start()
    {
        nbTokens = 0;
        RefreshTokens();
        nbChips = 0;
        RefreshChips();
    }

    public void RefreshChips()
    {
        textPoints.text = nbChips.ToString();
    }

    public void RefreshTokens()
    {
        textToken.text = nbTokens.ToString();
    }
}
