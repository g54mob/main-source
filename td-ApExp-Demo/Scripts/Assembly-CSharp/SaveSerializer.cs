using System;
using System.IO;
using UnityEngine;

public class SaveSerializer
{
	private string dir = "";

	private string filename = "";

	public string FilePath => Path.Combine(dir, filename);

	public SaveSerializer(string dir, string filename)
	{
		this.dir = dir;
		this.filename = filename;
	}

	public void Save<T>(T save) where T : class
	{
		string text = Path.Combine(dir, filename);
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(text));
			string value = JsonUtility.ToJson(save, prettyPrint: true);
			using FileStream stream = new FileStream(text, FileMode.Create);
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.Write(value);
		}
		catch (Exception ex)
		{
			Debug.LogError("Error occured when trying to save data to file: " + text + "\n" + ex);
		}
	}

	public T Load<T>() where T : class
	{
		string text = Path.Combine(dir, filename);
		if (File.Exists(text))
		{
			try
			{
				using FileStream stream = new FileStream(text, FileMode.Open);
				using StreamReader streamReader = new StreamReader(stream);
				return JsonUtility.FromJson<T>(streamReader.ReadToEnd());
			}
			catch (Exception ex)
			{
				Debug.LogError("Error occured when trying to load data to file: " + text + "\n" + ex);
			}
		}
		return null;
	}
}
