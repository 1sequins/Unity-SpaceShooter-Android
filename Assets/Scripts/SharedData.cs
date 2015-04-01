using UnityEngine;
using System.Collections;

public class SharedData : MonoBehaviour {

	// Game Progress Variables
	//public GUIText gameText;
	public string gameText;
	public int gameCount;
	public int lastScore;

	// Device specific Variables
	public bool hasTouch;
	public bool hasMultiTouch;

	// Playing Variables
	public bool MultiShot;
	public bool UpDown;
	public bool GameMute;
	public bool AutoFire;

	// Called once on Awake
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {

		gameCount = 0;
		hasTouch = Input.touchSupported;
		hasMultiTouch = Input.multiTouchEnabled;
		if (hasTouch) {
						gameText = "Touch to Start";
				} else {
						gameText = "Press key to Start";
				}
		MultiShot = true;
		UpDown = false;
		GameMute = false;
		AutoFire = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//
	// GoToSceneName changes scene to named scene passed in string
	//

	public void GoToSceneName(string inScene)
	{

		if (inScene != null) 
			{
					Application.LoadLevel (inScene);
			}
	}
	//
	// GoToSceneNumb changes scene to named scene passed in int
	//
	
	public void GoToSceneNumb(int inScene)
	{
			Application.LoadLevel (inScene);
	}

	//
	// GoExit closes the APP
	//

	public void GoExit()
	{
		Application.Quit();
		
	}

	//
	// Called from Set up screene
	//

//	public void MultiShootToggle(bool inToggle)
//		{
//		MultiShot = inToggle;
//		}

}
