using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
	public static SaveLoadManager Instance;

	private string directoryPath;

	private string path;

	[SerializeField]
	private List<int> unlockedIds;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		directoryPath = Application.persistentDataPath + "/Config";
		path = directoryPath + "/unlocks.json";
		CreateConfigDirectory();
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
		}
	}

	public List<int> LoadUnlockedIDs()
	{
		unlockedIds.Clear();
		string text = "";
		try
		{
			text = File.ReadAllText(path);
		}
		catch
		{
			MonoBehaviour.print("couldn't load unlocks at " + path);
			return null;
		}
		JSONNode jSONNode = JSON.Parse(text);
		for (int i = 0; i < jSONNode["unlockedIds"].Count; i++)
		{
			unlockedIds.Add(jSONNode["unlockedIds"][i]);
		}
		return unlockedIds;
	}

	public void SaveUnlockedIDs(List<GameObject> buildingOptions, List<GameObject> otherOptions, List<GameObject> waterOptions)
	{
		unlockedIds.Clear();
		foreach (GameObject buildingOption in buildingOptions)
		{
			if (buildingOption.GetComponent<GridObject>().IsUnlocked())
			{
				unlockedIds.Add(buildingOption.GetComponent<GridObject>().GetObjectID());
			}
		}
		foreach (GameObject otherOption in otherOptions)
		{
			if (otherOption.GetComponent<GridObject>().IsUnlocked())
			{
				unlockedIds.Add(otherOption.GetComponent<GridObject>().GetObjectID());
			}
		}
		foreach (GameObject waterOption in waterOptions)
		{
			if (waterOption.GetComponent<GridObject>().IsUnlocked())
			{
				unlockedIds.Add(waterOption.GetComponent<GridObject>().GetObjectID());
			}
		}
		string contents = JsonUtility.ToJson(new UnlockedIdsData(unlockedIds));
		File.WriteAllText(path, contents);
	}
}
