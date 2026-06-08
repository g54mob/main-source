using System.Collections.Generic;

public class GameSave
{
	public static string SAVE_FILE_NAME = "Primary Game";

	public static SaveFiles.SaveFileMeta selectedSaveFile;

	public static SaveFiles.SaveFileMeta activeSaveFile;

	public static SaveFiles.SaveFileMeta Save()
	{
		if (!ProgressFlags.GetFlag("show_stone"))
		{
			Utils.Log("Will not save progress. Too soon.");
			return null;
		}
		string uniqueId = null;
		if (activeSaveFile != null && activeSaveFile.saveId != null && !activeSaveFile.isDebug)
		{
			uniqueId = activeSaveFile.uniqueId;
			SaveFiles.singleton.Delete(activeSaveFile.saveId);
		}
		SaveFiles.SaveFileMeta saveFileMeta = (activeSaveFile = (selectedSaveFile = SaveFiles.singleton.SaveCurrentState(SAVE_FILE_NAME, uniqueId)));
		SaveFiles.singleton.storage.Save();
		Utils.LogIfEditor("[Save] " + saveFileMeta.ToString());
		return saveFileMeta;
	}

	public static void RestartProgress()
	{
		SaveFiles.singleton.DeleteSaveFileWithName(SAVE_FILE_NAME);
		SaveFiles.singleton.ClearActiveMemory();
	}

	public static string CopyProgressData()
	{
		SaveFiles.SaveFileMeta saveFileMeta = Save();
		if (saveFileMeta == null)
		{
			return "EMPTY";
		}
		return saveFileMeta.progressData;
	}

	public static void InitStorageType()
	{
		SaveFiles.singleton.storage = new SteamCloudStorage();
		GeneralPatches.PreStorageLoad(SaveFiles.singleton.storage);
	}

	public static void SelectTopSaveFile()
	{
		List<SaveFiles.SaveFileMeta> sorted = SaveFiles.singleton.GetSorted();
		if (sorted.Count > 0)
		{
			selectedSaveFile = sorted[0];
		}
		else
		{
			selectedSaveFile = new SaveFiles.SaveFileMeta();
		}
	}

	public static void ClearAllSaveFiles()
	{
		SaveFiles.singleton.ClearActiveMemory();
		SaveFiles.singleton.DeleteAllSaves();
		SaveFiles.singleton.storage.Clear();
		SaveFiles.singleton.storage.Save();
		SelectTopSaveFile();
	}
}
