using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    //Variables
    Rigidbody myRigidBody;
    [SerializeField]
    Vector3 force = new();

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.AddForce(new Vector3(-force.x, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.AddForce(new Vector3(force.x, 0, 0));
        }
    }
}
