using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Presets : MonoBehaviour
{
	public static List<Preset> presets = new List<Preset>();

	private void Awake()
	{
		TextAsset[] array = Resources.LoadAll<TextAsset>("Presets");
		foreach (TextAsset textAsset in array)
		{
			ReadPreset(textAsset.text);
		}
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.GetDataFolder("Presets")).GetFiles("*.preset");
			foreach (FileInfo fileInfo in files)
			{
				ReadPreset(File.ReadAllText(fileInfo.FullName), fileInfo.FullName);
			}
		}
		catch
		{
			Debug.Log("Presents folder couldn't be found.");
		}
	}

	private void ReadPreset(string data, string file = null)
	{
		try
		{
			string[] array = data.Split("\n"[0]);
			Preset preset = new Preset();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(":"[0]);
				preset.data.Add(array3[0].Trim(), array3[1].Trim());
			}
			preset.file = file;
			presets.Add(preset);
		}
		catch
		{
			Global.ShowMessage("Failed to load preset " + file);
		}
	}

	public static List<Preset> GetPresets(string type)
	{
		List<Preset> list = new List<Preset>();
		foreach (Preset preset in presets)
		{
			if (preset.data.ContainsKey("type") && preset.data["type"] == type)
			{
				list.Add(preset);
			}
		}
		return list;
	}
}
