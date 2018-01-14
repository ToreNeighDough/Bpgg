using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public GameObject Player;
    public Rigidbody rigid;
    private float power;
    private int number;
    public Slider PowerBarSlider;
    private float Direction;
    private bool ballThrow;
    public GameObject StartPos;
    public Text BallIn;
    private float timer;
    private const float MAXTIMER = 8;
    private int cupNumber;
    public GameObject[] cups;
    public GameObject[] cameras;
    public Canvas image;
    public Button[] buttons;
    public MeshRenderer ball;
    public AudioSource sfx;
    private int shots;



    // Use this for initialization
    void Start()
    {
        power = 0;
        number = 0;
        Direction = .75f;
        ballThrow = false;
        //BallIn.text = "";
        timer = MAXTIMER;
        cupNumber = 6;
        shots = 10;
    }

    public void Left()
    {
        Player.transform.Translate(new Vector3(-1, 0, 0));
    }

    public void Right()
    {
        Player.transform.Translate(new Vector3(1, 0, 0));
    }

   

    // Update is called once per frame
    void FixedUpdate()  
    {
        if (ballThrow == false)
        {
            if(PowerBarSlider.value == 0)
            {
                Direction *= -1;
            }

            if(PowerBarSlider.value == 1)
            {
                Direction *= -1;
            }

            PowerBarSlider.value += Direction * Time.deltaTime;

        }

        if(ballThrow == true)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                rigid.velocity = Vector3.zero;
                rigid.angularVelocity = Vector3.zero;
                rigid.useGravity = false;
                Player.transform.position = StartPos.transform.position;
                Player.transform.rotation = StartPos.transform.rotation;
                PowerBarSlider.value = 0;
                timer = MAXTIMER;
                ballThrow = false;
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
                image.worldCamera = cameras[0].GetComponent<Camera>();
                ball.enabled = true;
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].enabled = true;
                }
                if(shots <= 0)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }

    public void Throw()
    {
        shots--;
        ballThrow = true;
        power = PowerBarSlider.value * 135;
        rigid.AddForce(Vector3.forward * power);
        rigid.AddForce(Vector3.up * power);
        rigid.useGravity = true;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        sfx.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.name == "Cube")
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
            image.worldCamera = cameras[1].GetComponent<Camera>();
        }

        if (other.gameObject.name == "Cup (6)")
        {
            cups[0].gameObject.SetActive(false);
            ball.enabled = false;
            cupNumber--;
        }

        if (other.gameObject.name == "Cup (7)")
        {
            cups[1].gameObject.SetActive(false);
            ball.enabled = false;
            cupNumber--;
        }

        if (other.gameObject.name == "Cup (8)")
        {
            cups[2].gameObject.SetActive(false);
            ball.enabled = false;
            cupNumber--;
        }

        if (other.gameObject.name == "Cup (9)")
        {
            cups[3].gameObject.SetActive(false);
            ball.enabled = false;
            cupNumber--;
        }

        if (other.gameObject.name == "Cup (10)")
        {
            cups[4].gameObject.SetActive(false);
            ball.enabled = false;
            cupNumber--;
        }

        if (other.gameObject.name == "Cup (11)")
        {
            cups[5].gameObject.SetActive(false);
            ball.enabled = false;
            cupNumber--;
        }
        if(cupNumber == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {

    }
}
