using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int score = 0;
    float speed = 5.0f;

    public Button startButton;
    public Button continueButton;

    public Text scoreAmount;
    public Text youWin;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("Left Arrow");
            transform.Translate(-speed * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("Right Arrow");
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("Up Arrow");
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if ((Input.GetKey(KeyCode.DownArrow)))
        {
            //Debug.Log("Down Arrow");
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (score == 3)
        {
            youWin.text = "You Win!";
            PauseGame();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If touching coin
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            score++;
            scoreAmount.text = "Score: " + score;
        }
        if (collision.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            score = 0;
        }
        //Bounce off walls
        if (collision.gameObject.tag == "Walls")
        {
            //Debug.Log("Wall hit");
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Debug.Log("Left Arrow");
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("Right Arrow");
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("Up Arrow");
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if ((Input.GetKey(KeyCode.DownArrow)))
            {
                //Debug.Log("Down Arrow");
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
