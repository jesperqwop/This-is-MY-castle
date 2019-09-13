using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public float p1Points;
    public float p2Points;

    public Text p1Text;
    public Text p2Text;

    GameObject throne;

    // Start is called before the first frame update
    void Start()
    {
        throne = GameObject.FindGameObjectWithTag("Throne");
    }

    // Update is called once per frame
    void Update()
    {
        p1Text.text = "Points: " + Mathf.Round(p1Points).ToString();
        p2Text.text = "Points: " + Mathf.Round(p2Points).ToString();

    }

    private void FixedUpdate()
    {
        if(throne.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>().player == 1)
        {
            p1Points += 0.01f;
        }
        if (throne.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>().player == 2)
        {
            p2Points += 0.01f;
        }
    }

}
