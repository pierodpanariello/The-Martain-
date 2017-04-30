using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
	//GroundCheck
	public Transform groundCheck; 
	public float groundCheckRadius;
	public LayerMask whatIsGround; 


	public float movementSpeed;
	public float airMovementSpeed = 5f; 
	public float jumpForce;
	public float Moving; 
	public bool isGrounded;
	public Rigidbody2D rigidBody; 
	public Animator anim; 
	public bool isJumping; 

	// Use this for initialization
	void Start () {
		//Initializations 
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		isJumping = false; 
		
	}

	// Update is called once per frame
	void Update () {
		//GroundCheck 	
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 
		isJumping = !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


		//Animation keys 
		Moving = Mathf.Abs(rigidBody.velocity.x);
		anim.SetBool("Grounded", isGrounded);
		anim.SetFloat("Moving", Moving);
		anim.SetBool ("isJumping", isJumping);


		//If the player is pressing the right arrow or left arrow move accordingly 
		if (Input.GetKey (KeyCode.RightArrow) && isGrounded == true && isJumping == false) {
			//rigidBody.AddForce (Vector2.right * movementSpeed);
			rigidBody.velocity = new Vector2 (movementSpeed, 0); 
			transform.localScale = new Vector3 (5, 5, 5);
		} 

		if (Input.GetKey (KeyCode.LeftArrow) && isGrounded == true && isJumping == false) {
			//rigidBody.AddForce (Vector2.left * movementSpeed);
			rigidBody.velocity = new Vector2 (- movementSpeed, 0);
			transform.localScale = new Vector3 (-5, 5, 5);

		}
			

		//Air Controls 

		//To the left 
		if (Input.GetKey (KeyCode.LeftArrow) && isGrounded == false) {
			rigidBody.AddForce (Vector2.left * airMovementSpeed);
			//rigidBody.velocity = new Vector2 (- movementSpeed, 0);
			transform.localScale = new Vector3 (-5, 5, 5);

		}

		//To the right 
		if (Input.GetKey (KeyCode.RightArrow) && isGrounded == false) {
			rigidBody.AddForce (Vector2.right * airMovementSpeed);
			//rigidBody.velocity = new Vector2 (movementSpeed, 0); 
			transform.localScale = new Vector3 (5, 5, 5);
		} 







		//If the player is pressing the space key, then jump
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true && isJumping == false) {
			rigidBody.AddForce (Vector2.up * jumpForce);  

		} 
			
		//Keys for the animations

		
	}


}
