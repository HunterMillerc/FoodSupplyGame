using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(40, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddTorque(0, 0, -40);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.AddTorque(0, 0, 40);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-40, 0, 0);
        }

        
    }
}