using UnityEngine;
using System.Collections;

public class OpeningController : MonoBehaviour {
	public GUIText restartText;
	private SharedData manager;
	public GUIText scoreText;

	// Use this for initialization
	void Start () {


		GameObject managerObject = GameObject.FindGameObjectWithTag ("GameData");
		if (managerObject != null)
		{
			manager = managerObject.GetComponent <SharedData>();
		}
		if (manager == null)
		{
			Debug.Log ("Cannot find 'GameData' script");
		}

		scoreText.text = "No Scores saved";

		if (PlayerPrefs.HasKey ("HighScore")) 
		{
			//restartText.text = PlayerPrefs.GetInt ("HighScore").ToString ();
			scoreText.text = "High Score: " + PlayerPrefs.GetInt ("HighScore").ToString ();
			if (manager.lastScore != 0)
			{
				scoreText.text += "  Latest Score: " + manager.lastScore.ToString ();
			}
		}

		if (manager.lastScore >= PlayerPrefs.GetInt ("HighScore")) 
		{
			PlayerPrefs.SetInt("HighScore", manager.lastScore) ;
		}

		//_SaveAll ();

		//restartText.text = manager.gameText;
	}
	
	// Update is called once per frame
	void Update () {
//				if (Input.GetButton ("Fire1")) {
//
//						//manager.gameText = "Opening to Main";
//						
//						Application.LoadLevel ("Main");
//						//Application.LoadLevel (Application.loadedLevel);
//				}

				//restartText.text = "Accelerationz = " + Input.acceleration.z;
		//restartText.text = manager.GetComponent (SharedData).gameText.text;
		//restartText.text = manager.gameText + "OpCo";
		//restartText.text += manager.gameText;

		}

	public void GoMain()
	{
		Application.LoadLevel ("Main");
		
	}
	public void GoSetUp()
	{
		Application.LoadLevel ("SetUp");
		
	}

	public void GoOpening()
	{
		Application.LoadLevel ("Opening");
		
	}

	public void GoExit()
	{
		Application.Quit();
		
	}

	// Player Prefs Codes


	public void _UpdateAll()
	{

		}



	public void _SaveAll()
	{
				PlayerPrefs.SetInt ("HighScore", 27);

				//Application.LoadLevel (1);
		}

	public void _RestoreDefaults()
	{
				PlayerPrefs.DeleteAll ();
		// Application.LoadLevel(0);
				_UpdateAll ();
		}

	public void Play()
	{
				Application.LoadLevel (1);
		}

}
