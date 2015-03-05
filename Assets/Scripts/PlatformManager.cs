using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour 
{
	public float speed;
	public Vector3 basePos;
	Animator animator;

	// Use this for initialization
	void Start() 
	{
		speed    = 1.5f;
		basePos  = transform.position;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate()
	{
		transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);

		if (transform.position.y <= Camera.main.collider2D.bounds.min.y)
		{
			transform.position = new Vector3 (transform.position.x, Camera.main.collider2D.bounds.max.y, 0);
			animator.SetBool("fire", false);
		}

		if (transform.position.x < -4) 
		{
			transform.Translate (9, 0, 0);
		}

		if (transform.position.y <= Camera.main.collider2D.bounds.min.y + 1.6f) 
		{
			animator.SetBool("fire", true);
		}
	}
}
