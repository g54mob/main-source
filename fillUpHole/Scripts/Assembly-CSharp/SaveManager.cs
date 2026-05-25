using System;
using UnityEngine;
using V1;

public class SaveManager
{
	public static AppData AppData;

	public static MainData GameData;

	public static void SaveGameData()
	{
		if (GameData != null)
		{
			ApiManager.Instance.SaveGame(GetJsonFromSaveGameData(GameData));
		}
	}

	public static bool HasGameSaveData()
	{
		return ApiManager.Instance.HasSave();
	}

	public static void LoadGameData()
	{
		if (HasGameSaveData())
		{
			GameData = GetSaveGameDataFromJson(ApiManager.Instance.LoadGame());
		}
	}

	public static void ClearGameSaveData()
	{
		ApiManager.Instance.ClearSave();
		GameData = null;
	}

	public static MainData GetSaveGameDataFromJson(string json)
	{
		MainData result = null;
		if (json.Contains(MainData.GetVersion()))
		{
			result = JsonUtility.FromJson<MainData>(json);
		}
		return result;
	}

	public static string GetJsonFromSaveGameData(MainData data)
	{
		string text = "";
		try
		{
			return JsonUtility.ToJson(data);
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static void SaveAppData()
	{
		if (AppData != null)
		{
			ApiManager.Instance.SaveApplication(GetJsonFromSaveAppData(AppData));
		}
	}

	public static bool HasAppSaveData()
	{
		return ApiManager.Instance.HasApplication();
	}

	public static void LoadAppData()
	{
		if (HasAppSaveData())
		{
			AppData = GetSaveAppDataFromJson(ApiManager.Instance.LoadApplication());
		}
	}

	public static void ClearAppSaveData()
	{
		AppData = null;
	}

	public static AppData GetSaveAppDataFromJson(string json)
	{
		AppData result = null;
		if (json.Contains(AppData.GetVersion()))
		{
			result = JsonUtility.FromJson<AppData>(json);
		}
		return result;
	}

	public static string GetJsonFromSaveAppData(AppData data)
	{
		string text = "";
		try
		{
			return JsonUtility.ToJson(data);
		}
		catch (Exception)
		{
			return "";
		}
	}
}
