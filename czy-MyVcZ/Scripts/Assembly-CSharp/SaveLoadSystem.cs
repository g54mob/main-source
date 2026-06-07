using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SaveLoadSystem
{
	private static readonly string _path = Application.persistentDataPath + "/save.json";

	private const string KEY_WORD = "sdhfioshdio@#%#@%@$@dgfi!~@$#joash";

	public static void SaveGame(GameSaveData gameSaveData)
	{
		string data = JsonConvert.SerializeObject(gameSaveData, Formatting.Indented);
		File.WriteAllText(_path, EncryptAndDecrypt(data));
		Debug.Log("Saved game data to: " + _path);
	}

	public static GameSaveData LoadGame()
	{
		if (File.Exists(_path))
		{
			GameSaveData? result = JsonConvert.DeserializeObject<GameSaveData>(EncryptAndDecrypt(File.ReadAllText(_path)));
			Debug.Log("Loaded game data from: " + _path);
			return result;
		}
		return null;
	}

	private static string EncryptAndDecrypt(string data)
	{
		string text = "";
		for (int i = 0; i < data.Length; i++)
		{
			text += (char)(data[i] ^ "sdhfioshdio@#%#@%@$@dgfi!~@$#joash"[i % "sdhfioshdio@#%#@%@$@dgfi!~@$#joash".Length]);
		}
		return text;
	}
}
