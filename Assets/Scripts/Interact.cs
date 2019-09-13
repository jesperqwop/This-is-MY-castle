using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public bool chair;
    public bool player;
    public GameObject playerContact;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Chair")
        {
            chair = true;
        }
        if (other.tag == "Player")
        {
            player = true;
            playerContact = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Chair")
        {
            chair = false;
        }
        if (other.tag == "Player")
        {
            player = true;
            playerContact = null;
        }
    }
}
