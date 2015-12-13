using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

	public Rigidbody2D target;
	Vector2 targetPos;
	
	public float posSmoothTime = 1;
	Vector2 posVel = Vector2.zero;

	float size;
	float sizeSmoothTime = .5f;
	float sizeVel = 0;

	Camera cam;
	
	void Awake()
	{
		cam = GetComponent<Camera> ();
		targetPos = target.position;
		size = cam.orthographicSize;
	}
	
	void Update () {
		if (target != null) {
			targetPos = target.position;
		}
		Vector2 newPos = Vector2.SmoothDamp (transform.position, targetPos, ref posVel, posSmoothTime);
		transform.position = new Vector3 (newPos.x, newPos.y, transform.position.z);

		cam.orthographicSize = Mathf.SmoothDamp (cam.orthographicSize, size, ref sizeVel, sizeSmoothTime);
	}

	public void SetSize(float s)
	{
		size = s;
	}

	public float GetSize()
	{
		return cam.orthographicSize;
	}
}
