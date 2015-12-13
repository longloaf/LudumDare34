using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	Cam cam;

	void Awake()
	{
		cam = GameObject.Find ("Main Camera").GetComponent<Cam> ();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void Finish()
	{
		cam.SetSize (cam.GetSize () / 2);
	}
}
