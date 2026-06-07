using System;
using UnityEngine;
using V1;

public class SaveManager
{
	public static AppData AppData;

	public static MainData GameData;

	public static void SaveGameData(int saveId)
	{
		if (GameData != null)
		{
			ApiManager.Instance.SaveGame(saveId, GetJsonFromSaveGameData(GameData));
		}
	}

	public static bool HasGameSaveData(int saveId)
	{
		return ApiManager.Instance.HasSave(saveId);
	}

	public static void LoadGameData(int saveId)
	{
		if (HasGameSaveData(saveId))
		{
			GameData = GetSaveGameDataFromJson(ApiManager.Instance.LoadGame(saveId));
		}
	}

	public static MainData GetGameData(int saveId)
	{
		if (!HasGameSaveData(saveId))
		{
			return null;
		}
		return GetSaveGameDataFromJson(ApiManager.Instance.LoadGame(saveId));
	}

	public static void ClearGameSaveData(int saveId)
	{
		ApiManager.Instance.ClearSave(saveId);
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
