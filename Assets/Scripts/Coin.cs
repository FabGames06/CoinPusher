using UnityEngine;

public class Coin : MonoBehaviour
{


    void Update()
    {
        Vector3 position = transform.position;
        if(position.y>0f && position.y<.1f)
        {
            // +1 jeton
            GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            gm.nbTokens++;
            gm.RefreshTokens();
            Destroy(gameObject);
        }
    }
}
