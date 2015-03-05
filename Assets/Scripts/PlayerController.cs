using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Animator animator;
	public bool grounded;
	public GameObject groundChecker;
	public LayerMask groundCheckLayerMask;
	public bool canJump;

	// Use this for initialization
	void Start() 
	{
		animator = GetComponent<Animator>();
		canJump  = true;
	}

	void FixedUpdate()
	{
		UpdateGroundStatus();
		if (Input.GetButton ("Fire1") && canJump) 
		{
			grounded = false;
			animator.SetBool ("landing", false);
			
			canJump = false;
			rigidbody2D.AddForce (new Vector2 (0, 180));
			animator.SetTrigger ("jump");
		} 

		if (transform.position.y <= Camera.main.collider2D.bounds.min.y + 1.8f)
		{
			animator.SetBool("burn", true);
		}	
	}

	void UpdateGroundStatus()
	{
		grounded = Physics2D.OverlapCircle (groundChecker.transform.position, 0.1f, groundCheckLayerMask);

		if (grounded && !canJump)
		{
			animator.SetBool ("landing", true);
			canJump = true;
		}
	}
}
