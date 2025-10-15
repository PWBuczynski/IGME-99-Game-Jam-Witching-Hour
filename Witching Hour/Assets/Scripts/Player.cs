using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int score = 0;
    float speed = 5.0f;
    
    public Text scoreAmount;
    
    //Nothing is needed in Start.
    void Start()
    {

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
    
}
