using UnityEngine;

public class StackManager : MonoBehaviour
{
    public GameObject coin;
    public GameObject silver;
    public GameObject token;
    private int nbCoins = 100;
    private int nbTokens = 10;
    private GameManager gm;
    void Start()
    {
        // 1ère pile
        for(int i = 0; i < nbCoins; i++)
        {
            float posX = Random.Range(-1.4f, 1.4f);
            float posY = Random.Range(2f, 2.07f);
            float posZ = Random.Range(-.4f, 0f);
            Vector3 position = new Vector3(posX, posY, posZ);
            int chance = Random.Range(0, 2);
            if(chance == 0)
                Instantiate(coin, position, Quaternion.identity);
            else
                Instantiate(silver, position, Quaternion.identity);
        }
        
        // 2è pile
        for (int i = 0; i < nbCoins; i++)
        {
            float posX = Random.Range(-1.4f, 1.4f);
            float posY = Random.Range(1.5f, 1.57f);
            float posZ = Random.Range(-.6f, -.9f);
            Vector3 position = new Vector3(posX, posY, posZ);
            int chance = Random.Range(0, 2);
            if (chance == 0)
                Instantiate(coin, position, Quaternion.identity);
            else
                Instantiate(silver, position, Quaternion.identity);
        }

        // 3è pile
        for (int i = 0; i < nbCoins; i++)
        {
            float posX = Random.Range(-1.4f, 1.4f);
            float posY = Random.Range(1f, 1.07f);
            float posZ = Random.Range(-1.7f, -1.5f);
            Vector3 position = new Vector3(posX, posY, posZ);
            int chance = Random.Range(0, 2);
            if (chance == 0)
                Instantiate(coin, position, Quaternion.identity);
            else
                Instantiate(silver, position, Quaternion.identity);
        }

        // pile de tokens machiques
        float posiX = Random.Range(-1.4f, 1.4f);

        float posiZ = Random.Range(-.4f, 0f);
        for(int i = 0; i < nbTokens; i++)
        {
            Vector3 position = new Vector3(posiX, 3+i*.15f, posiZ);
            Instantiate(token, position, Quaternion.identity);
        }

        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && gm.nbTokens>0) // 0 = clic gauche
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // empecher au clic de "shake !" de cramer un jeton
            if (Physics.Raycast(ray, out hit) && hit.point.x>-1.4f && hit.point.x<1.4f)
            {
                Vector3 clickPosition = hit.point;
                clickPosition.z = Mathf.Clamp(clickPosition.z, 0f, 0.3f);
                //Debug.Log("Position du clic : " + clickPosition);

                gm.nbTokens--;
                if (gm.nbTokens < 0)
                    gm.nbTokens = 0;

                gm.RefreshTokens();

                Instantiate(coin, clickPosition, Quaternion.identity);
            }
        }
    }
}
