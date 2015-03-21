using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText utilityText;
	
	private bool inplay;
	private bool gameOver;
	private bool restart;
	//private bool endplay;
	private int score;
	private SharedData manager;

	void Start()
	{
		inplay = true;
		gameOver = false;
		restart = false;
		//endplay = false;
		restartText.text = "";
		gameOverText.text = "";
		utilityText.text = "";
		score = 0;
		UpdateScore ();

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
		//utilityText.text = manager.gameText ;

		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (!inplay)		//gameOver
		{
//			if (Input.GetButton("Fire1"))
//				{
////				if (!restart) 
////					{
////					Application.Quit();
////					}
//				if (restart) 
//				{
					manager.gameCount +=1;
//					manager.gameText  = "Touch to ReStart (" + manager.gameCount + ")" ;

					manager.lastScore = score;
					//Application.LoadLevel (Application.loadedLevel);
					Application.LoadLevel ("Opening");
//				}

//			}
			//manager.gameText = "GameController Update";
		}
		//restartText.text = "Accelerationz = " + Input.acceleration.z;
		//restartText.text = manager.gameText.text + "GameController";
		//utilityText.text = manager.gameText + " B";

		}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (inplay)
		{
			for (int i= 0;i < hazardCount;i++) 
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(waveWait);


			waveWait -= 0.5f;
			if (waveWait <= 0.5f) { waveWait = 0.5f; }
			//utilityText.text = "Wave Wait " + waveWait;


			if (gameOver)
			{
//				restartText.text = "Touch to Replay";
				restart = true;
				inplay = false;
				break;
			}

		}  //endwhile inplay
//		while (!inplay) 
//		{
//			yield return new WaitForSeconds(waveWait);
//			
//			if (restart)
//			{
//				restartText.text = "Touch to Quit";
//				restart = false;
//				//endplay = true;
//				break;
//			}
//
//		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}


}
