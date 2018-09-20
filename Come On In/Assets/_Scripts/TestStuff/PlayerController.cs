using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for Player movement
public class PlayerController : MonoBehaviour 
{
	public Transform pivot;

	public float speed;
	public Vector3 playerMove{set;get;}

	public Transform trans;
//	public Transform camTransform;

	void Update ()
	{
		PlayerMove();
//		trans.LookAt (camTransform);
	
	}

	public void PlayerMove ()
	{
		transform.Translate(speed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, speed*Input.GetAxis("Vertical")*Time.deltaTime);
	}

	//private void RotateWithCamera ()
	//{
	//	if(camTransform != null)
	//	{
	//	//	trans = camTransform.rotation.y;
	//	} 

	//	else
	//	{
	//		camTransform = Camera.main.transform;
	//	}
	//}
}
