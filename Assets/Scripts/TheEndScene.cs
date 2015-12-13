using UnityEngine;
using System.Collections;

public class TheEndScene : MonoBehaviour {
	
	void Start () {
		Invoke ("GotoMenu", 3);
	}

	void GotoMenu()
	{
		Application.LoadLevel ("Menu");
	}

}
