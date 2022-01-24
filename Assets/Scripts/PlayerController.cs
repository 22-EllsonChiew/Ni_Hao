using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Movement Speed
    public float speed;

    Rigidbody playerRb;

    //Score Text
    public Text scoreText;
    public int Score;

    public int y;

    //Sound Effect
    private AudioSource playSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        y = SceneManager.GetActiveScene().buildIndex;
        playSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Control
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        //Movement
        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical);

        transform.position += moveDirection * speed;

        //Win Scene
        if (Score == 10 && y == 0)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (Score == 15 && y == 1)
        {
            SceneManager.LoadScene("Level3");
        }
        else if (Score == 16 && y == 2)
        {
            SceneManager.LoadScene("Level4");
        }
        else if (Score == 16 && y == 3)
        {
            SceneManager.LoadScene("GameWin");
        }

        if (Score == 16)
        {
            //SceneManager.LoadScene("GameWin");
            //SceneManager.LoadScene("Level4");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hazard")
        {
            //Lose Scene
            SceneManager.LoadScene("GameLose");
            //Debug.Log("die");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            playSound.Play();
            Score += 1;
            scoreText.GetComponent<Text>().text = "Coins Collected: " + Score;
            Destroy(other.gameObject);
        }
    }
}
