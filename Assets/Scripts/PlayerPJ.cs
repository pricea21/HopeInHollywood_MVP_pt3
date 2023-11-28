using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPJ : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 5;
    public bool onGroud;
    public GameObject youWin;
    public GameObject instructionsUI;
    public GameObject settingsButton;

    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.firstTime)
        {
            instructionsUI.SetActive(true);
            Time.timeScale = 0f;
            GameManager.firstTime = false;
        }

        if (GameManager.firstTime == false)
        {
            settingsButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGroud)
        {
            rb.velocity = rb.velocity + Vector2.up * 4;
            onGroud = false;
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Platform"))
        {
            onGroud = true;
        }

        if (collision.gameObject.tag == ("Enemy") || collision.gameObject.tag == ("Edge"))
        {
            instructionsUI.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            settingsButton.SetActive(true);
        }

        if (collision.gameObject.tag == ("BackDoor"))
        {
            youWin.SetActive(true);
            GameManager.instance.SetMinigameComplete("Platform Jumper");
            Invoke("Next", 2);
        }
    }

    public void Next()
    {
        SceneManager.LoadScene("Map");
    }
}
