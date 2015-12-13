using UnityEngine;
using System.Collections;

public class RotatingObject : MonoBehaviour {

	public float angSpeed = 180;
	
	void FixedUpdate()
	{
		transform.Rotate (0, 0, angSpeed * Time.deltaTime);
	}
}
