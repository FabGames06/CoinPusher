using UnityEngine;

public class Chip : MonoBehaviour
{
    void Update()
    {
        Vector3 position = transform.position;
        if(position.y>0f && position.y<.1f)
        {
            // +1 jeton poker "chip"
            GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            gm.nbChips+=5000;
            gm.RefreshChips();
            Destroy(gameObject);
        }
    }
}
