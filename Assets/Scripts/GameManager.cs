using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public const string LAST_LEVEL = "last_level";

	Text progress;

	Cam cam;

	GameObject player;
	bool restartFlag = false;

	void Awake()
	{
		int lastLevel = PlayerPrefs.GetInt (LAST_LEVEL);
		if (Application.loadedLevel > lastLevel) {
			PlayerPrefs.SetInt(LAST_LEVEL, Application.loadedLevel);
		}

		progress = GameObject.Find ("Progress").GetComponent<Text> ();
		int n = Application.loadedLevel;
		progress.text = n.ToString ("00") + "/" + (Application.levelCount - 2).ToString ("00");

		cam = GameObject.Find ("Main Camera").GetComponent<Cam> ();

		player = GameObject.Find ("Player");
	}
	
	void Update () {
		if (player == null && !restartFlag) {
			restartFlag = true;
			Invoke("RestartLevel", 1);
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			RestartLevel();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}
		#if UNITY_EDITOR
		if (Input.GetKeyDown (KeyCode.N)) {
			NextLevel();
		}
		#endif
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

	void RestartLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
