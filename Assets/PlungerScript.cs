using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    public float Power;
    public float MinPower = 0f;
    public float MaxPower = 100;
    public Slider PowerSlider;
    List<Rigidbody> BallList;
    bool BallReady;

    void Start()
    {
        PowerSlider.minValue = 0f;
        PowerSlider.maxValue = MaxPower;
        BallList = new List<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (BallReady)
        {
            PowerSlider.gameObject.SetActive(true);
        }
        else
        {
            PowerSlider.gameObject.SetActive(false);
        }


        PowerSlider.value = Power;
        if (BallList.Count > 0)
        {
            BallReady = true;

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Power <= MaxPower)
                {
                    Power += 500 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                foreach (Rigidbody r in BallList)
                {
                    r.AddForce(Power * Vector3.forward);
                }
            }
        }
        else
        {
            BallReady = false;
            Power = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            BallList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        BallList.Remove(other.gameObject.GetComponent<Rigidbody>());
        Power = 0f;
    }
}
