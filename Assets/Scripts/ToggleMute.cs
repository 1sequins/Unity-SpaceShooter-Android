using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleMute : MonoBehaviour {
	Toggle _Toggle = null;
	bool _Loaded = false;
	
	private SharedData manager;
	
	void Awake()
	{
		_Toggle = GetComponent<Toggle>();
		//	LoadValue();
	}
	
	void Start()
	{
		GameObject managerObject = GameObject.FindGameObjectWithTag ("GameData");
		
		if (managerObject != null) {
			manager = managerObject.GetComponent <SharedData> ();
		}
		if (manager == null) {
			Debug.Log ("Cannot find 'GameData' script");
		}
		LoadValue();
	}
	//	void OnClick()
	//	{
	//		UpdateValue (_Toggle.isOn);
	//		}
	
	void LoadValue()
	{
		_Toggle.isOn = manager.GameMute;
		//Debug.Log("Loading... " + _Toggle.isOn);
		_Loaded = true;
	}
	
	public void UpdateValue(bool value)
	{
		//Debug.Log("UpdateValue... " + _Toggle.isOn + " - " + _Loaded);
		if (!_Loaded)
			return;
		
		manager.GameMute = _Toggle.isOn;
		//Debug.Log("UpDown... " + manager.UpDown);
		if (_Toggle.isOn)
		{
			AudioListener.pause = true; 
			AudioListener.volume = 0;
		}
		else
		{
			AudioListener.pause = false;
			AudioListener.volume = 0.5f;
		}

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

}
