using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int score = 0;
    public static int coinAmount = 5;
    float speed = 5.0f;
    public GameObject coinPrefab;

    public GameObject[] coinList = new GameObject[coinAmount];

    public Vector3[] spawnList = new Vector3[10];
    
    public Text scoreAmount;
    
    //Nothing is needed in Start.
    void Start()
    {
        //Possible locations for coin spawning
        spawnList[0] = new Vector3(-6.54f,4.29f,0);
        spawnList[1] = new Vector3(-4.36f, 4.29f, 0);
        spawnList[2] = new Vector3(-8.69f, -1.04f, 0);
        spawnList[3] = new Vector3(-2.51f, -1.39f, 0);
        spawnList[4] = new Vector3(0, 2.50f, 0);
        spawnList[5] = new Vector3(2.65f, -2.45f, 0);
        spawnList[6] = new Vector3(3.83f, -0.67f, 0);
        spawnList[7] = new Vector3(6.38f, 0.95f, 0);
        spawnList[8] = new Vector3(6.32f, 2.38f, 0);
        spawnList[9] = new Vector3(2.13f, 2.65f, 0);

        for (int i = 0; i < coinAmount; i++)
        {
            Vector3 spawnPosition;
            bool positionTaken;
            do
            {
                positionTaken = false;
                int randomInt = Random.Range(0, 10);
                spawnPosition = spawnList[randomInt];
                for (int j = 0; j < i; j++)
                {
                    if (coinList[j] != null && coinList[j].transform.position == spawnPosition)
                    {
                        positionTaken = true;
                        break;
                    }
                }   
            }
            while (positionTaken);
            coinList[i] = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Game controls
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If touching coin your score goes up and the coin disappears
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            SpawnCoin(collision.gameObject);
            score++;
            scoreAmount.text = "Score: " + score;
        }
        //If touching enemy the game resets
        if (collision.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            score = 0;
        }
        //Bounce off walls
        if (collision.gameObject.tag == "Walls")
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if ((Input.GetKey(KeyCode.S)))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
    public GameObject SpawnCoin(GameObject coin)
    {
        int randomInt = Random.Range(0,10);
        GameObject newObject = Instantiate(coinPrefab, spawnList[randomInt], Quaternion.identity);
        Debug.Log($"{spawnList[randomInt].x} {spawnList[randomInt].y} {spawnList[randomInt].z}");
        return newObject;
    }
}
