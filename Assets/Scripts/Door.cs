using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Sprite openedSprite;
	public Sprite closedSprite;

	public bool startOpened = true;
	bool opened;

	public float[] delays;
	int delay_id;
	float timer;

	public bool loopSwitch = true;

	SpriteRenderer rend;
	Collider2D coll;

	void Awake()
	{
		rend = GetComponent<SpriteRenderer> ();
		coll = GetComponent<Collider2D> ();

		opened = startOpened;
		UpdateState ();

		if (delays.Length > 0) {
			delay_id = 0;
			timer = 0;
		} else {
			delay_id = -1;
		}
	}

	int Mod(int a, int b)
	{
		int r = a % b;
		if (r < 0) {
			r += b;
		}
		return r;
	}

	void Update ()
	{
		if (delay_id >= 0) {
			timer += Time.deltaTime;
			float del = delays[delay_id];
			if (timer >= del) {
				timer -= del;
				delay_id = (delay_id + 1) % delays.Length;
				if ((delay_id != 0) || loopSwitch) {
					SwitchState();
				}
			}
		}
	}

	void SwitchState()
	{
		opened = !opened;
		UpdateState ();
	}

	void UpdateState()
	{
		if (opened) {
			rend.sprite = openedSprite;
			coll.enabled = false;
		} else {
			rend.sprite = closedSprite;
			coll.enabled = true;
		}
	}
}
