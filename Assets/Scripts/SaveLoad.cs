//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;
//
//public static class SaveLoad {
//	
//	public static List<Game> savedGames = new List<Game>();
//	
//	//it's static so we can call it from anywhere
//	public static void Save() {
//		SaveLoad.savedGames.Add(Game.current);
//		BinaryFormatter bf = new BinaryFormatter();
//		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
//		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
//		bf.Serialize(file, SaveLoad.savedGames);
//		file.Close();
//	}  
//	
//	public static void Load() {
//		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
//			BinaryFormatter bf = new BinaryFormatter();
//			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
//			SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
//			file.Close();
//		}
//	}
//}


//================================================================

//using UnityEngine;
//using System.Collections;
//
//[System.Serializable]
//public class Game {
//	
//	public static Game current;
//	public Character knight;
//	public Character rogue;
//	public Character wizard;
//	
//	public Game () {
//		knight = new Character();
//		rogue = new Character();
//		wizard = new Character();
//	}
//	
//}

//===============================================================

//using UnityEngine;
//using System.Collections;
//
//[System.Serializable]
//public class Character {
//	
//	public string name;
//	
//	public Character () {
//		this.name = "";
//	}
//}

