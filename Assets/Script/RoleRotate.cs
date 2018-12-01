using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleRotate : MonoBehaviour
{

	public Camera RoleCamera;
	private float mRotateSpeed = 250;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton(0))
		{
			float offx = Input.GetAxis("Mouse X");
			//float offy = Input.GetAxis("Mouse Y");
			if (offx != 0)
				transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * mRotateSpeed * -offx);

			//if (offy != 0)
			//	transform.RotateAround(transform.position, transform.right, Time.deltaTime * mRotateSpeed * offy);
		}

		float offset = Input.GetAxis("Mouse ScrollWheel");
		if (RoleCamera != null && offset != 0)
			RoleCamera.fieldOfView -= offset * 20;
	}
}
