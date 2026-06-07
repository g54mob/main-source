using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
	public static bool TryGetDayAndMoney(int saveSlot, out int day, out float money, out bool endlessMode)
	{
		string path = Application.persistentDataPath + "/" + saveSlot + "DEMOsave.data";
		day = 0;
		money = 0f;
		endlessMode = false;
		if (!File.Exists(path))
		{
			return false;
		}
		try
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			SaveData saveData = binaryFormatter.Deserialize(fileStream) as SaveData;
			fileStream.Close();
			if (saveData == null)
			{
				return false;
			}
			day = saveData.curDay;
			money = saveData.money;
			endlessMode = saveData.endlessMode;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void ResetSave(int saveSlot)
	{
		string path = Application.persistentDataPath + "/" + saveSlot + "DEMOsave.data";
		if (File.Exists(path))
		{
			File.Delete(path);
			Debug.Log("Save file deleted.");
		}
		else
		{
			Debug.Log("No save file found to delete.");
		}
	}

	public static void SaveState(SaveManager saveMan)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = new FileStream(Application.persistentDataPath + "/" + PlayerPrefs.GetInt("CurSaveSlot", 0) + "DEMOsave.data", FileMode.Create);
		SaveData graph = new SaveData(saveMan);
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static SaveData LoadState()
	{
		string text = Application.persistentDataPath + "/" + PlayerPrefs.GetInt("CurSaveSlot", 0) + "DEMOsave.data";
		if (File.Exists(text))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream(text, FileMode.Open);
			SaveData result = binaryFormatter.Deserialize(fileStream) as SaveData;
			fileStream.Close();
			return result;
		}
		Debug.LogError("Save file not found in " + text);
		return null;
	}
}
