using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float forceMag = 10;
	public float forceAng = 45;

	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	Vector2 Vec2(float mag, float ang_deg)
	{
		float ang_rad = ang_deg * Mathf.Deg2Rad;
		return new Vector2 (mag * Mathf.Cos (ang_rad), mag * Mathf.Sin (ang_rad));
	}

	void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.AddForce(Vec2 (forceMag, forceAng), ForceMode2D.Force);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce(Vec2(forceMag, 180 - forceAng), ForceMode2D.Force);
		}
	}
}
