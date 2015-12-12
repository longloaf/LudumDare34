using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
