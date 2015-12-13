using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	Text progress;

	Cam cam;

	void Awake()
	{
		progress = GameObject.Find ("Progress").GetComponent<Text> ();
		int n = Application.loadedLevel;
		progress.text = n.ToString ("00") + "/" + (Application.levelCount - 2).ToString ("00");

		cam = GameObject.Find ("Main Camera").GetComponent<Cam> ();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}
	}

	public void Finish()
	{
		cam.SetSize (cam.GetSize () / 2);
		Invoke ("NextLevel", 2);
	}

	void NextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
