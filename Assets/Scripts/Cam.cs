using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

	[SerializeField] Rigidbody2D target;
	Vector2 targetPos;
	
	[Space(10)]
	
	[SerializeField] float posSmoothTime = 1;
	Vector2 posVel = Vector2.zero;
	
	[Space(10)]
	
	[SerializeField] AnimationCurve sizeCurve;
	[SerializeField] float sizeSmoothTime = 1;
	float sizeVel;
	
	Camera cam;
	
	void Awake()
	{
		cam = GetComponent<Camera> ();
		targetPos = target.position;
	}
	
	void Update () {
		float targetVel = 0;
		if (target != null) {
			targetPos = target.position;
			targetVel = target.velocity.magnitude;
		}
		Vector2 newPos = Vector2.SmoothDamp (transform.position, targetPos, ref posVel, posSmoothTime);
		transform.position = new Vector3 (newPos.x, newPos.y, transform.position.z);
		
		cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, sizeCurve.Evaluate(targetVel), ref sizeVel, sizeSmoothTime);
	}
}
