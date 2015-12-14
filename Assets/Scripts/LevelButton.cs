using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButton : MonoBehaviour {

	int level_id = 0;

	public Text label;

	public void LoadLevel()
	{
		Application.LoadLevel (level_id);
	}

	public void SetLevelId(int id)
	{
		level_id = id;
		label.text = id.ToString ("00");
	}
}
