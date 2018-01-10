using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public GameObject Player;
    public Rigidbody rigid;
    private float power;
    public GameObject[] cubes;
    public Material[] cubeColours;
    private int number;

    // Use this for initialization
    void Start()
    {
        power = 0;
        number = 0;
        InvokeRepeating("PowerBar", 1, .05f);
    }

    private void PowerBar()
    {
        cubes[number].GetComponent<MeshRenderer>().material = cubeColours[0];
        number++;

        if(number > cubes.Length)
        {
            number = 29;
        }
    }

    // Update is called once per frame
    void FixedUpdate()  
    {
        
            if (Input.GetButton("Right")) {
            switch (number)
            {
                case 0:
                    power = 1;
                    break;

                case 1:
                    power = 2;
                    break;

                case 2:
                    power = 3;
                    break;

                case 3:
                    power = 4;
                    break;

                case 4:
                    power = 5;
                    break;

                case 5:
                    power = 6;
                    break;

                case 6:
                    power = 7;
                    break;

                case 7:
                    power = 8;
                    break;

                case 8:
                    power = 9;
                    break;

                case 9:
                    power = 10;
                    break;

                case 10:
                    power = 11;
                    break;

                case 11:
                    power = 12;
                    break;

                case 12:
                    power = 13;
                    break;

                case 13:
                    power = 14;
                    break;

                case 14:
                    power = 15;
                    break;

                case 15:
                    power = 16;
                    break;

                case 16:
                    power = 17;
                    break;

                case 17:
                    power = 18;
                    break;

                case 18:
                    power = 19;
                    break;

                case 19:
                    power = 20;
                    break;

                case 20:
                    power = 21;
                    break;

                case 21:
                    power = 22;
                    break;

                case 22:
                    power = 23;
                    break;

                case 23:
                    power = 24;
                    break;

                case 24:
                    power = 25;
                    break;

                case 25:
                    power = 26;
                    break;

                case 26:
                    power = 27;
                    break;

                case 27:
                    power = 28;
                    break;

                case 28:
                    power = 29;
                    break;

                case 29:
                    power = 30;
                    break;

            }
            
            
            CancelInvoke("PowerBar");
            rigid.AddForce(Vector3.forward * power);
            rigid.AddForce(Vector3.up * power);
            rigid.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "playerTwo")
        {
            Debug.Log("Collision With Player Two");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
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
