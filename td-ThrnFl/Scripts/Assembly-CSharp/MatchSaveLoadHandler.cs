using System;
using System.IO;
using UnityEngine;

public static class MatchSaveLoadHandler
{
	private static string currentMap = "Neuland(Tutorial)";

	private static MatchSave currentSave;

	public static bool OverwriteCurrentSave = false;

	private static string SavePath => Application.persistentDataPath + "/" + currentMap + ".json";

	public static bool SaveLoadForbidden => currentMap == "Neuland(Tutorial)";

	public static MatchSave CurrentSave => currentSave;

	public static bool IsLoadingPermitted
	{
		get
		{
			if (CurrentSave == null || OverwriteCurrentSave)
			{
				return false;
			}
			if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial && (EternalTrialsRunManager.CurrentRun.currentStageSeed != CurrentSave.etSeed || EternalTrialsRunManager.CurrentRun.runComplete))
			{
				OverwriteCurrentSave = true;
				return false;
			}
			return true;
		}
	}

	public static string GetPathFromIdentifierAndGUID(string guid, string identifier)
	{
		return guid + "_" + identifier;
	}

	public static bool TryLoadValue<T>(string guid, string identifier, ref T value)
	{
		if (CurrentSave == null)
		{
			return false;
		}
		return CurrentSave.TryLoadValue(GetPathFromIdentifierAndGUID(guid, identifier), ref value);
	}

	public static void SaveValue(string guid, string identifier, string value)
	{
		CurrentSave.AddValue(GetPathFromIdentifierAndGUID(guid, identifier), value);
	}

	public static void SaveValue(string guid, string identifier, int value)
	{
		CurrentSave.AddValue(GetPathFromIdentifierAndGUID(guid, identifier), value);
	}

	public static void SaveValue(string guid, string identifier, float value)
	{
		CurrentSave.AddValue(GetPathFromIdentifierAndGUID(guid, identifier), value);
	}

	public static void SaveValue(string guid, string identifier, bool value)
	{
		CurrentSave.AddValue(GetPathFromIdentifierAndGUID(guid, identifier), value);
	}

	public static void SaveValue(string guid, string identifier, int[] value)
	{
		CurrentSave.AddValue(GetPathFromIdentifierAndGUID(guid, identifier), value);
	}

	public static void SaveValue(string guid, string identifier, TagManager.ETag[] value)
	{
		CurrentSave.AddValue(GetPathFromIdentifierAndGUID(guid, identifier), value);
	}

	public static void InitializeCurrentSave()
	{
		if (currentSave == null || OverwriteCurrentSave)
		{
			currentSave = new MatchSave();
		}
		OverwriteCurrentSave = false;
	}

	public static void SaveRun()
	{
		if (currentSave == null)
		{
			Debug.Log("No data found to save.");
			return;
		}
		try
		{
			currentSave.ConvertObjectDataToStrings();
			string contents = JsonUtility.ToJson(CurrentSave);
			File.WriteAllText(SavePath, contents);
			Debug.Log("Match Data successfully saved.");
		}
		catch
		{
			Debug.LogError("There has been an error while trying to save the current match data.");
		}
	}

	public static void MarkRunCompleteAndSave()
	{
		if (currentSave != null)
		{
			currentSave.runComplete = true;
			SaveRun();
		}
	}

	public static void TryLoadRun(string mapName)
	{
		currentMap = mapName;
		currentSave = null;
		try
		{
			if (File.Exists(SavePath))
			{
				currentSave = JsonUtility.FromJson<MatchSave>(File.ReadAllText(SavePath));
				currentSave.ConvertStringsToObjectData();
				Debug.Log("Match Save loaded.");
			}
			else
			{
				Debug.Log("No Save Data for Match found.");
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("There has been an error while trying to load the current match save." + ex);
		}
	}

	public static void SubmitScoreAndSave(int score)
	{
		if (currentSave != null)
		{
			if (score > currentSave.highestScoreThisRun)
			{
				currentSave.highestScoreThisRun = score;
			}
			SaveRun();
		}
	}
}
