using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySaveLoad
{
	public static SuccessStatus SaveAsBinary<T>(T objectToSave, string pathWithinPersistentDataPath)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		string text = ConstructPath(pathWithinPersistentDataPath);
		string text2 = ConstructPath(pathWithinPersistentDataPath) + ".bac";
		CreateDirectories(text);
		if (File.Exists(text))
		{
			if (File.Exists(text2))
			{
				File.Copy(text, text2, overwrite: true);
			}
			else
			{
				File.Move(text, text2);
			}
		}
		try
		{
			FileStream fileStream = File.Create(text);
			binaryFormatter.Serialize(fileStream, objectToSave);
			fileStream.Close();
			return SuccessStatus.Success;
		}
		catch (Exception arg)
		{
			string[] array = text.Split('/', '\\');
			for (int i = 0; i < array.Length - 1; i++)
			{
				string text3 = array[0];
				for (int j = 1; j <= i; j++)
				{
					text3 = Path.Combine(text3, array[j]);
				}
				string text4 = Path.Combine(Constants.persistentDataPath, text3);
				if (!Directory.Exists(text4))
				{
					Debug.LogError($"Save Exception: {arg}, path not found: {text4}");
					break;
				}
			}
			return SuccessStatus.Failed;
		}
	}

	private static string ConstructPath(string path)
	{
		if (!path.Contains(Constants.persistentDataPath))
		{
			path = Path.Combine(Constants.persistentDataPath, path);
		}
		if (!path.EndsWith(".sav"))
		{
			path += ".sav";
		}
		return path;
	}

	public static T LoadFromBinary<T>(string pathWithinPersistentDataPath, out SuccessStatus successStatus)
	{
		string text = ConstructPath(pathWithinPersistentDataPath);
		successStatus = SuccessStatus.Failed;
		if (File.Exists(text))
		{
			try
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				using FileStream fileStream = File.Open(text, FileMode.Open);
				if (fileStream.Length > 0)
				{
					T result = (T)binaryFormatter.Deserialize(fileStream);
					fileStream.Close();
					successStatus = SuccessStatus.Success;
					return result;
				}
			}
			catch (Exception arg)
			{
				Debug.LogError($"Save File corrupted {text}. Exception: {arg}");
				string text2 = text + ".bac";
				if (File.Exists(text2))
				{
					try
					{
						BinaryFormatter binaryFormatter2 = new BinaryFormatter();
						using FileStream fileStream2 = File.Open(text2, FileMode.Open);
						if (fileStream2.Length > 0)
						{
							T result2 = (T)binaryFormatter2.Deserialize(fileStream2);
							fileStream2.Close();
							successStatus = SuccessStatus.BackupLoaded;
							File.Copy(text2, text, overwrite: true);
							File.Delete(text2);
							return result2;
						}
					}
					catch (Exception arg2)
					{
						Debug.LogError($"Backup File corrupted {text2}. Exception: {arg2}");
					}
				}
			}
		}
		else
		{
			successStatus = SuccessStatus.Success;
		}
		return default(T);
	}

	public static void CreateDirectories(string path)
	{
		new FileInfo(path).Directory?.Create();
	}
}
