using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {

	public float speed;

	public float tilt;
	public Boundary boundary;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	public GUIText utilityText;
	
	private float nextFire;
	private bool useAccelerometer;
	private float moveHorizontal;
	private float moveVertical;

	private bool shotEnable;

	private SharedData manager;

	// To manage fire rate
	private GameObject[] Bolts;
	private int numBolts;

	void Start()
	{
		useAccelerometer = true;
		if (Input.acceleration.z >= 0) {
			useAccelerometer = false;
				}

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

	void Update ()
	{
		Bolts = GameObject.FindGameObjectsWithTag ("Bolt");

//		if (Bolts.length != 0) {
//			numBolts = Bolts.Length();		
//				} else {
//			numBolts = 0;
//				}
		numBolts = 0;

		foreach (GameObject thisbolt in Bolts)
		{
			numBolts +=1;
		}


		shotEnable = (manager.AutoFire == true || Input.GetButtonDown ("Fire1"));



		//utilityText.text = "Bolts = " + numBolts;
		if (manager.MultiShot == true || numBolts == 0) 
			{
				//if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) { // && numBolts < 1)
			if (shotEnable == true && Time.time > nextFire)
			{
						nextFire = Time.time + fireRate;
							//GameObject clone =   Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
							Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
							audio.Play ();
						}
				}
	}

	void FixedUpdate ()
	{
		if (!useAccelerometer) {
						moveHorizontal = Input.GetAxis ("Horizontal");
						moveVertical = Input.GetAxis ("Vertical");
				} else {
						moveHorizontal = Input.acceleration.x;
						moveVertical = -Input.acceleration.y;
				}
		if (!manager.UpDown) {
						moveVertical = 0.0f;
				}
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, -moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);

	}
	}
