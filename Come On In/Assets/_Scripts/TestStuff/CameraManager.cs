﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AP
{
	

	public class CameraManager : MonoBehaviour 
	{
		public bool lockOn;
		public float followSpeed = 9;
		public float mouseSpeed = 2;
		public float controllerSpeed = 7;

		public Transform target;

		public Transform pivot;
		public Transform camTrans;

		//StateManager states;

		float turnSmoothing = .1f;
		public float minAngle = -35;
		public float maxAngle = 35;

		float smoothX;
		float smoothY;
		float smoothXvelocity;
		float smoothYvelocity;
		public float lookAngle;
		public float tiltAngle;

		bool usedRightAxis;

		//public void Init(StateManager st)
		//{
		//	states = st;
		//	target = st.transform;

		//	camTrans = Camera.main.transform;
		//	pivot = camTrans.parent;
		//}

		public void Tick(float d)
		{
			float h = Input.GetAxis ("Mouse X");
			float v = Input.GetAxis ("Mouse Y");

			float c_h = Input.GetAxis ("RightJoyLR");
			float c_v = Input.GetAxis ("RightJoyUD");

			float targetSpeed = mouseSpeed;

//			if (lockonTarget != null) 
//			{
//				if (lockOnTransform == null) 
//				{
//					lockOnTransform = lockonTarget.GetTarget();
//					states.lockOnTransform = lockOnTransform;
//				}
//				if (Mathf.Abs (c_h) > 0.6f) 
//				{
//					if (!usedRightAxis) 
//					{
//						lockOnTransform = lockonTarget.GetTarget ((c_h > 0));
//						states.lockOnTransform = lockOnTransform;
//						usedRightAxis = true;
//					}
//				}
//			}
			if (usedRightAxis)
			{
				if (Mathf.Abs(c_h)>0.6f)
				{
					usedRightAxis = false;
				}
			}

			if (c_h != 0 || c_v != 0)
			{
				h = c_h;
				v = c_v;
				targetSpeed = controllerSpeed;
			}

			FollowTarget (d);
			HandleRotations (d, v, h, targetSpeed);
		}

		void FollowTarget(float d)
		{
			float speed = d * followSpeed;
			Vector3 targetPosition = Vector3.Lerp (transform.position, target.position, speed);
			transform.position = targetPosition;
		}

		void HandleRotations(float d, float v, float h, float targetSpeed)
		{
			if (turnSmoothing > 0)
			{
				smoothX = Mathf.SmoothDamp (smoothX, h, ref smoothXvelocity, turnSmoothing);
				smoothY = Mathf.SmoothDamp (smoothY, v, ref smoothYvelocity, turnSmoothing);
			}
			else
			{
				smoothX = h;
				smoothY = v;
			}
			tiltAngle -= smoothY * targetSpeed;
			tiltAngle = Mathf.Clamp (tiltAngle, minAngle, maxAngle);
			pivot.localRotation = Quaternion.Euler (tiltAngle, 0, 0);

//			if(lockonTarget == false)
//				lockOn = false;
//
//			if (lockOn)
//			{
//				Vector3 targetDir = lockOnTransform.position - transform.position;
//				targetDir.Normalize ();
//				//targetDir.y = 0;
//
//				if (targetDir == Vector3.zero)
//					targetDir = transform.forward;
//				
//				Quaternion targetRot = Quaternion.LookRotation (targetDir);
//				transform.rotation = Quaternion.Slerp (transform.rotation, targetRot, d * 9);
//				lookAngle = transform.eulerAngles.y;
//				return;
//			}


			lookAngle += smoothX * targetSpeed;
			transform.rotation = Quaternion.Euler (0, lookAngle, 0);

	

		}

		public static CameraManager singleton;

		void Awake()
		{
			singleton = this;
		}
			
	}
}