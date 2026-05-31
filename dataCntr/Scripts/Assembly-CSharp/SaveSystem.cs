using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public delegate void OnSavingData();

	public delegate void OnLoadingData();

	public delegate void OnLoadingDataLater();

	public static List<string> listofsaves;

	private static string saveDirPath;

	public static OnSavingData onSavingData;

	public static OnLoadingData onLoadingData;

	public static OnLoadingDataLater onLoadingDataLater;

	public static string loadSaveName;

	public static int version;

	public static int versionToIgnoreFrom;

	public static void SaveGame(string savename = null, string stringNameOfSave = null)
	{
	}

	public static SaveData LoadGame(string savename)
	{
		return null;
	}

	public static void DeleteSaveFile(string savename)
	{
	}

	public static BinaryFormatter GetBinaryFormatter()
	{
		return null;
	}

	public static void SaveGameData()
	{
	}

	private static List<string> Listofsaves()
	{
		return null;
	}

	public static string NewestSave()
	{
		return null;
	}

	public static void LoadGameData()
	{
	}

	public static void Load(string savename, bool isFromPauseMenu)
	{
	}

	public static void AutoSave()
	{
	}
}
