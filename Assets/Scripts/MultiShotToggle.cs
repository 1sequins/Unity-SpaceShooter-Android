using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiShotToggle : MonoBehaviour
{
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
		_Toggle.isOn = manager.MultiShot;
		//Debug.Log("Loading... " + _Toggle.isOn);
		_Loaded = true;
	}
	
	public void UpdateValue(bool value)
	{
	//	Debug.Log("UpdateValue... " + _Toggle.isOn + " - " + _Loaded);
		if (!_Loaded)
			return;
		
		manager.MultiShot = _Toggle.isOn;
	//	Debug.Log("MultiShot... " + manager.MultiShot);

	}
}
