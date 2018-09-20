using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonCam : MonoBehaviour 
{

	public Transform lookAt;				//What the Camera is looking at
	public Transform camTransform;			//Transform of Camera

	private Camera cam;						//Main Camera

	private const float Y_ANGLE_Min = -10.0f;
	private const float Y_ANGLE_Max = 50.0f;

	private float distance = 7.0f;			//Distance between Player and Camera
	private float currentX = 0.0f;			//Used to Calculate Camera Position
	private float currentY = 0.0f;			// ^^Same
	//private float sensitivityX = 4.0f;
	//private float sinsitivityY = 1.0f;

	private void Start()
	{
		camTransform = transform;			//Transform of Camera at game start
		cam = Camera.main;					//pulls first "Main Camera" to use as camera
	}

	private void Update()
	{
		currentX += Input.GetAxis("Mouse X");
		currentY -= Input.GetAxis("Mouse Y");

		currentY = Mathf.Clamp(currentY, Y_ANGLE_Min, Y_ANGLE_Max);		 //Sets max/min range of rotation for Camera on y Axis
	}

	private void LateUpdate()
	{
		Vector3 dir = new Vector3(0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt(lookAt.position);
	}

}
