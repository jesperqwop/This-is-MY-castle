using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerNR;
    public float pushForce;
    public bool onThrone;
    public float moveHorizontal;
    public float moveVertical;
    Vector3 movement;
    public bool canMove;
    public bool canTurn;
    Rigidbody rb;
    public float speed;
    public GameObject interact;
    public GameObject sitPosition;
    GameObject throne;
    bool moving;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        throne = GameObject.FindGameObjectWithTag("Throne");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (canMove == true)
        {
            rb.AddForce(movement * speed);
        }
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            if (canTurn == true)
            {
                Vector3 angle = gameObject.transform.eulerAngles;


                angle.y = (Mathf.Atan2(moveVertical, moveHorizontal * -1) * Mathf.Rad2Deg + 90);


                Quaternion q_angle = Quaternion.Euler(angle);

                gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, q_angle, 0.75f);
            }
        }

        if(interact.GetComponent<Interact>().chair == true)
        {
            if (Input.GetButtonDown("Submit"))
            {
                Sit();
            }
        }

        if (interact.GetComponent<Interact>().player == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Push();
            }
        }

        if (onThrone == true)
        {
            transform.position = sitPosition.transform.position;
            transform.rotation = sitPosition.transform.rotation;
        }
        else
        {
            if(moveHorizontal == 0  && moveVertical == 0)
            {
                animator.SetBool("Walk", false);

            }
            else
            {
                animator.SetBool("Walk",true);
            }
        }

    }

    void Sit()
    {
        onThrone = true;
        throne.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>().player = playerNR;
    }

    void Push()
    {
        interact.GetComponent<Interact>().playerContact.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(interact.GetComponent<Interact>().playerContact.transform.position - transform.position) * pushForce);
    }

}
