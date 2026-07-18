using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;

public class RoofColorLoader : MonoBehaviour
{
	private string directoryPath;

	private string path;

	private void Start()
	{
		directoryPath = Application.persistentDataPath + "/Config";
		path = directoryPath + "/colors.json";
		CreateConfigDirectory();
		LoadColors();
	}

	private bool CheckIfDirectoryExists(string _directoryPath)
	{
		return Directory.Exists(_directoryPath);
	}

	private void CreateConfigDirectory()
	{
		if (!CheckIfDirectoryExists(directoryPath))
		{
			Directory.CreateDirectory(directoryPath);
			CopyConfigFile();
		}
		if (!File.Exists(path))
		{
			CopyConfigFile();
		}
	}

	private void CopyConfigFile()
	{
		TextAsset textAsset = Resources.Load<TextAsset>("colors");
		try
		{
			File.WriteAllText(path, textAsset.text);
		}
		catch
		{
			MonoBehaviour.print("something went wrong!");
		}
	}

	private void LoadColors()
	{
		string aJSON = "";
		try
		{
			aJSON = File.ReadAllText(path);
		}
		catch
		{
			MonoBehaviour.print("couldn't load colors at " + path);
		}
		JSONNode jSONNode = JSON.Parse(aJSON);
		List<Color> list = new List<Color>();
		JSONNode.Enumerator enumerator = jSONNode["colors"].GetEnumerator();
		while (enumerator.MoveNext())
		{
			JSONNode jSONNode2 = enumerator.Current;
			list.Add(GetColorFromHex(jSONNode2["hexvalue"]));
		}
		GridController.Instance.SetRoofColorsList(list);
	}

	private Color GetColorFromHex(string _hexValue)
	{
		if (ColorUtility.TryParseHtmlString(_hexValue, out var color))
		{
			return color;
		}
		return Color.black;
	}
}
