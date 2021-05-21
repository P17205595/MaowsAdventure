using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clsPM : MonoBehaviour
{
    // Declaration of variables
    private float playerSpeed;
    private float walkSpeed;
    private float runSpeed;
    public static int coinAmount;
    public static int ballAmount;
    public static int foodAmount;

    Rigidbody rb;

    private float jumpForce;
    private Vector3 jump;
    private bool isGrounded;

    // Note to self: start is called before the first frame update, is called the moment that the game starts/the very first frame of runtime

    void Start()
    {
        playerSpeed = walkSpeed; // Assign floating point number. NTS: 0.01f is lowest possible value, this is the value the player will move by.
        walkSpeed = 5f;
        runSpeed = 9f;
        //playerCharacter = GameObject.Find("Player");

        jumpForce = 2.0f;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        coinAmount = 0;
        ballAmount = 0;
        foodAmount = 0;

    }

    public static int incrementCoins()
    {
        coinAmount = coinAmount + 1;
        return coinAmount;
    }

    public static int incrementBall()
    {
        ballAmount = ballAmount + 1;
        return ballAmount;
    }

    public static int incrementFood()
    {
        foodAmount = foodAmount + 1;
        return foodAmount;
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

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}