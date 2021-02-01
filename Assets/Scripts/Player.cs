using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidComponent;
    private float horizontalInput;
    private bool spaceWasPressed;
    private bool isGrounded;
    private bool rightWasPressed;
    private bool leftWasPressed;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        rigidComponent = GetComponent<Rigidbody>();
        spaceWasPressed = false;
        rightWasPressed = false;
        leftWasPressed = false;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spaceWasPressed = true;
        }
      
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidComponent.velocity = new Vector3(horizontalInput * 1.6f, rigidComponent.velocity.y, 0);
        if(spaceWasPressed && Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length != 0)
        {
            rigidComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            spaceWasPressed = false;
        }
        //if(leftWasPressed)
        //{
        //    rigidComponent.AddForce(Vector3.left * 1, ForceMode.Force);
        //}
        //if (rightWasPressed)
        //{
        //    rigidComponent.AddForce(Vector3.right * 1, ForceMode.Force);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Debug.Log(other.gameObject.name);
            Destroy(other.gameObject);
            Score.scoreValue += 10;
        }
    }




}
