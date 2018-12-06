using UnityEngine;

using System.Collections;



public class Controller : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    private void Start()
    {
        // Grab the controller from the character controller
        controller = this.GetComponent<CharacterController>();
        
    }

    void Update()
    {
        // When the player is on the ground
        if (controller.isGrounded)
        {
            // moveDirection is equal to the horizontal axis and vertical axis
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // moveDirection changes your direction depending on which axis you are facing
            moveDirection = transform.TransformDirection(moveDirection);

            // The speed at which the player moves
            moveDirection *= speed;

            // When jump is pressed
            if (Input.GetButton("Jump"))
            {
                // Increase the player's y axis for a very short ammount of time
                moveDirection.y = jumpSpeed;
            }
        }
        // Gravity will pull the player down in real time
        moveDirection.y -= gravity * Time.deltaTime;
        // Player movement is calculated in real time
        controller.Move(moveDirection * Time.deltaTime);
    }
}
