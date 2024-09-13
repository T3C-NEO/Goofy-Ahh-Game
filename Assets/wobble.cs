using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wobble : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 turnSpeed = new Vector3(0,0,0.4f);
    Vector3 turnSpeedX = new Vector3(0.4f,0,0);

    public bool fall = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Switch()
    {
        fall = !fall;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fall == false)
        {
            if (transform.rotation.eulerAngles.z > 5 && transform.rotation.eulerAngles.z < 150)
            {
                rb.angularVelocity -= turnSpeed;
            }
            else if (transform.rotation.eulerAngles.z < 355 && transform.rotation.eulerAngles.z > 200)
            {
                rb.angularVelocity += turnSpeed;
            }

            if (transform.rotation.eulerAngles.x > 5 && transform.rotation.eulerAngles.x < 150)
            {
                rb.angularVelocity -= turnSpeedX;
            }
            else if (transform.rotation.eulerAngles.x < 355 && transform.rotation.eulerAngles.x > 200)
            {
                rb.angularVelocity += turnSpeedX;
            }
        }
    }
}
