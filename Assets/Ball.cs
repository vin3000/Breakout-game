using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Variables
    int lives = 3;
    Rigidbody myRigidBody;

    [SerializeField]
    Vector3 force = new();
    [SerializeField]
    GameObject textGameObject;
    [SerializeField]
    TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.AddForce(force.x, force.y, force.z);
        textComponent = textGameObject.GetComponent<TextMeshProUGUI>();
        string livesText = "Lives: " + lives;
        textComponent.text = livesText;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 6;
        myRigidBody.velocity = myRigidBody.velocity.normalized * speed;
        if (transform.position.y < -1 && lives > 0)
        {
            lives--;
            string livesText = "Lives: " + lives;
            textComponent.text = livesText;
            transform.position = new Vector3(0, 3, 0);
        }
        else if(lives == 0)
        {
            transform.position = new Vector3(0, 3, 0);
            StartCoroutine(ExampleCoroutine());
            lives = 3;
            textComponent.text = "Lives " + lives;
            print("done");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject block = collision.gameObject;
        if (block.name.Contains("Block"))
        {
            Destroy(block);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        Renderer rend = GetComponent<Renderer>();

        //yield on a new YieldInstruction that waits for 5 seconds.
        for (int blink = 0; blink < 2; blink++)
        {
            myRigidBody.constraints = RigidbodyConstraints.FreezeAll;
            print(blink + 1);
            rend.enabled = false;
            yield return new WaitForSeconds(1);
            rend.enabled = true;
            yield return new WaitForSeconds(1);
            myRigidBody.constraints = RigidbodyConstraints.None;
            myRigidBody.AddForce(force.x, -force.y, force.z);
        }
    }
}
