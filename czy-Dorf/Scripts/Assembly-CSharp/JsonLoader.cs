using System.IO;
using UnityEngine;

public static class JsonLoader
{
	private static string LoadJsonFromDataLocation(string subPath, DataLocation dataLocation)
	{
		string text = Path.Combine(DataLocationPath.GetPath(dataLocation), subPath);
		Debug.Log("tries to load file at path " + text);
		return File.ReadAllText(text);
	}

	public static T LoadJsonFromDataLocation<T>(string subPath, DataLocation dataLocation = DataLocation.PersistentDataPath)
	{
		Debug.Log($"Tries loading Json from {subPath} in {dataLocation}");
		if (!Exists(subPath, dataLocation))
		{
			return default(T);
		}
		return JsonUtility.FromJson<T>(LoadJsonFromDataLocation(subPath, dataLocation));
	}

	public static bool Exists(string pathWithinPersistentDataPath, DataLocation dataLocation)
	{
		return File.Exists(Path.Combine(DataLocationPath.GetPath(dataLocation), pathWithinPersistentDataPath));
	}
}
