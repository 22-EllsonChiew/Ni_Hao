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

    public Text scoreText;
    public int Score;

    public int y;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        y = SceneManager.GetActiveScene().buildIndex;
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
            SceneManager.LoadScene("GameWin");
        }

        print(y);
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
            Score += 1;
            scoreText.GetComponent<Text>().text = "Coins Collected: " + Score;
            Destroy(other.gameObject);
        }
    }
}
