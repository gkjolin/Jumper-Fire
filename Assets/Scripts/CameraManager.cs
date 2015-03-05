using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {

	public List<GameObject> platforms;

	public float cameraSpeed;


	// Use this for initialization
	void Start() 
	{
		Application.targetFrameRate = 40;
		cameraSpeed = .5f;
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.position += new Vector3 (0, cameraSpeed * Time.deltaTime, 0);
	}
}
