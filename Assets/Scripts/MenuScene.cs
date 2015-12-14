using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScene : MonoBehaviour {

	public GameObject levels;
	public GameObject levelButton;

	void Awake()
	{
		int lastLevel = PlayerPrefs.GetInt (GameManager.LAST_LEVEL);
		if (lastLevel < 1) {
			lastLevel = 1;
		}
		int levelCount = Application.levelCount - 2;
		for (int i = 1; i <= levelCount; ++i) {
			GameObject buttonObject = Instantiate<GameObject>(levelButton);
			LevelButton buttonScript = buttonObject.GetComponent<LevelButton>();
			buttonScript.SetLevelId(i);
			buttonObject.transform.SetParent(levels.transform);
			if (i > lastLevel) {
				Button button = buttonObject.GetComponentInChildren<Button>();
				button.interactable = false;
			}
		}
	}

	void Update()
	{
		#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.X)) {
			PlayerPrefs.SetInt(GameManager.LAST_LEVEL, 0);
			Application.LoadLevel(Application.loadedLevel);
		}
		#endif
	}
}
