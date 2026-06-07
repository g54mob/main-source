using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
	public string filename;

	public string txt;

	public string title;

	public abstract List<string>[] io();

	private void Start()
	{
		string path = Application.dataPath + "/Resources/Task/" + filename + ".txt";
		if (File.Exists(path))
		{
			StreamReader streamReader = File.OpenText(path);
			title = streamReader.ReadLine();
			txt = streamReader.ReadToEnd();
			txt = title + "\n" + txt;
			streamReader.Close();
		}
	}

	public string RandomString(int length, string chars, List<string> invalid)
	{
		string text = "";
		for (int i = 0; i < length; i++)
		{
			int startIndex = Random.Range(0, chars.Length);
			text += chars.Substring(startIndex, 1);
		}
		if (invalid.Contains(text))
		{
			return RandomString(length, chars, invalid);
		}
		return text;
	}

	public string RandomString(int length, string chars)
	{
		string text = "";
		for (int i = 0; i < length; i++)
		{
			int startIndex = Random.Range(0, chars.Length);
			text += chars.Substring(startIndex, 1);
		}
		return text;
	}
}
