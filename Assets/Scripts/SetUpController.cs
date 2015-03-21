using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetUpController : MonoBehaviour {

	private SharedData manager;


	//private ToggleExample toggleManager;


	bool _isSpawnSpeed = false;

	
	// Establish Toggles
	void Awake()
	{


	}


	// Use this for initialization
	void Start()
	{

		//manager = GetGameObject (GameManager);
		GameObject managerObject = GameObject.FindGameObjectWithTag ("GameData");
		
		if (managerObject != null)
		{
			manager = managerObject.GetComponent <SharedData>();
		}
		if (manager == null)
		{
			Debug.Log ("Cannot find 'GameData' script");
		}



	}

	// Update is called once per frame
	void Update () {
		//LoadValue();  //Load toggles from SharedData
		//UpdateValue ();  // Should be onClicks and on exit!!
	}

	// OnDestroy called as scene closes
	void OnDestroy() {
		}

	public void GoSceneNum(int manInt)
	{
		manager.GoToSceneNumb (manInt);	
	}

	public void GoSetUp()
	{
		Application.LoadLevel ("SetUp");
	}
	
	public void GoSceneName(string manString)
	{
		manager.GoToSceneName (manString);
	}
	
	public void GoExit()
	{
		manager.GoExit ();
	}

	//
	// Called from Set up screene
	//
	public void MuteToggle()
	{
		if (AudioListener.pause)
		{
			AudioListener.pause = false;
		}
		else
		{
			AudioListener.pause = true; // false
		}
		
		AudioListener.volume = 0; // what value to return to 1??
	}

	//
	// Clear High Score
	//
	public void ClearHighScore()
	{
		if (PlayerPrefs.HasKey ("HighScore")) 
		{
			PlayerPrefs.SetInt ("HighScore", 0);
		}
		manager.lastScore = 0;
	}

	
}

