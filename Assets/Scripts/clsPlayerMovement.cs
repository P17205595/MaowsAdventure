using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clsPlayerMovement : MonoBehaviour
{
    // Declaration of variables
    // We will declare any variables here
    // e.g public int playerScore; public/private = access modifier. int - data type (e.g. int is whole numbers). playerScore = 
    private float playerSpeed;
    private float walkSpeed;
    private float runSpeed;

    private Vector3 playerPosition; // Vector 3 = variable that stores 3 values. i.e store players 3D position x y z
    private GameObject playerCharacter; // GameObject = Unity 3D object

    Rigidbody rb;

    private float jumpForce;
    private Vector3 jump;
    private bool isGrounded;

    // Start is called before the first frame update, is called the moment that the game starts/the very first frame of runtime

    void Start()
    {
        playerSpeed = walkSpeed; // Assign floating point number. 0.01f is lowest possible value, this is the value the player will move by.
        walkSpeed = 0.01f;
        runSpeed = 0.03f;
        playerCharacter = GameObject.Find("Player");

        jumpForce = 2.0f;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    // Update is being called constantly
    // Any methods/functions that need to be constantly called/executed put here
    void Update()
    {

        playerPosition = playerCharacter.transform.position; //playerposition variable/vector3 var is assigned the players current x/y/z position
                                                             // Cartesian = x/y/z 3D position, refer to it in report as Cartesian/3D


        if (Input.GetKey(KeyCode.A))
        {
            playerPosition.x -= playerSpeed; // players x axis position is decremented by playerSpeed/float var
            playerCharacter.transform.position = playerPosition;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerPosition.x += playerSpeed; // players x axis position is incremented by playerSpeed/float var
            playerCharacter.transform.position = playerPosition;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //playerPosition.z += playerSpeed; // players z axis position is incremented by playerSpeed/float var
            //playerCharacter.transform.position = playerPosition;
            transform.Translate(0.01f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerPosition.z -= playerSpeed; // players z axis position is decremented by playerSpeed/float var
            playerCharacter.transform.position = playerPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Set current speed to run if shift is down
            playerSpeed = runSpeed;
        }
        else
        {
            // Otherwise set current speed to walking speed
            playerSpeed = walkSpeed;
        }



        UpdatePlayerPosition(); // call method is updated to player position
    }

    void UpdatePlayerPosition()
    {
        playerCharacter.transform.position = playerPosition; //
    }
}
