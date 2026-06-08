using System.IO;
using UnityEngine;

public static class JsonSaver
{
	public static void SaveAsJson<T>(T objectToSave, string pathWithinPersistentDataPath)
	{
		string text = Path.Combine(Constants.persistentDataPath, pathWithinPersistentDataPath);
		Debug.Log("Save JSON file " + text);
		CreateDirectories(pathWithinPersistentDataPath);
		string contents = JsonUtility.ToJson(objectToSave, prettyPrint: true);
		File.WriteAllText(text, contents);
	}

	private static void CreateDirectories(string pathWithinPersistentDataPath)
	{
		string[] array = pathWithinPersistentDataPath.Split('/', '\\');
		for (int i = 0; i < array.Length - 1; i++)
		{
			string text = array[0];
			for (int j = 1; j <= i; j++)
			{
				text = Path.Combine(text, array[j]);
			}
			string path = Path.Combine(Constants.persistentDataPath, text);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
	}
}
