using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Author: Mohammed Alghamdi
Popuse: this file encapsulates all the code related to the hero movement.
 */
public class PlayerMovement : MonoBehaviour
{
    // horizental and veritcal coordinates at the beginning of the level
    private float xCoordOrigin;
    private float yCoordOrigin;

    // horizental and veritcal coordinates currently
    private float xCoordCurr;
    private float yCoordCurr;

    // those 2 variables assures that the hero movements will be smooth.
    public float lerbRate, speed;
    private bool canDash; // retrieved from the memory


    // those variables are used for controlling the jump
    private bool isGrounded;
    private bool canDoubleJump;
    private bool canDoubleJumpInitial; // retrieved from the memory
    public float initialJumpRate, doubleJumpRate;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xCoordCurr = transform.position.x;
        xCoordOrigin = transform.position.x;
        yCoordCurr = transform.position.y;
        yCoordOrigin = transform.position.y;
        isGrounded = true;
        canDoubleJumpInitial = true;
        canDoubleJump = canDoubleJumpInitial;
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        // updating coordinates
        yCoordCurr = transform.position.y;
        xCoordCurr = transform.position.x;

        // horizontal movements
        if (Input.GetKey(KeyCode.D))
            stepRight(); 
        else if (Input.GetKey(KeyCode.A)) 
            stepLeft();
        // dashing
        if (Input.GetKeyDown("s") && canDash)
            speed = speed * 3f;
        else if (Input.GetKeyUp("s") && canDash)
            speed = speed / 3f;
        
        // vartical movements
        if (Input.GetKeyDown("w"))
            jump();
    }


    // make the character move one step to the right.
    private void stepRight() {
        // TODO rotate right
        xCoordCurr += speed;
        Vector3 tempPos = new Vector3(transform.position.x, yCoordCurr, 0);
        Vector3 targetPos = new Vector3(xCoordCurr, yCoordCurr, 0);
        tempPos = Vector3.Lerp(tempPos, targetPos, lerbRate * Time.deltaTime);;
        transform.position = tempPos;
    }


    // make the character move one step to the left.
    private void stepLeft() {
        // TODO rotate left
        xCoordCurr -= speed;
        Vector3 tempPos = new Vector3(transform.position.x, yCoordCurr, 0);
        Vector3 targetPos = new Vector3(xCoordCurr, yCoordCurr, 0);
        tempPos = Vector3.Lerp(tempPos, targetPos, lerbRate * Time.deltaTime);;
        transform.position = tempPos;
    }


    // let the character do the jump whether it is a single or a double.
    private void jump() {
        if (isGrounded) {
          rb.AddForce (0f, initialJumpRate, 0f); 
          isGrounded = false;
        } else if (canDoubleJump) {
            rb.AddForce (0f, doubleJumpRate, 0f);
            canDoubleJump = false;
        }
    }


    
    void OnCollisionEnter (Collision other){
		isGrounded = true;
        canDoubleJump = canDoubleJumpInitial;
	}
 
}
