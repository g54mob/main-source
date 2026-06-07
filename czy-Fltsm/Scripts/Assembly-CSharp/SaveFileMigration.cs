using System;
using System.Collections.Generic;
using System.IO;
using M4.Session;
using UnityEngine;

public static class SaveFileMigration
{
	public static readonly string OLD_AUTOSAVES_DIRECTORY = Application.persistentDataPath + "/Saves/Autosaves/";

	private static List<SaveMetaInfo> _savesToMigrate;

	private static void Initialize()
	{
		if (_savesToMigrate == null)
		{
			_savesToMigrate = new List<SaveMetaInfo>(128);
			PopulateSavesToMigrate(SaveInfo.PLAYER_SAVES_DIRECTORY, "*.fs", _savesToMigrate);
			PopulateSavesToMigrate(OLD_AUTOSAVES_DIRECTORY, "*.fs", _savesToMigrate);
		}
	}

	private static void PopulateSavesToMigrate(string directory, string searchPattern, List<SaveMetaInfo> savesToMigrate)
	{
		if (!Directory.Exists(directory))
		{
			return;
		}
		string[] files = Directory.GetFiles(directory, searchPattern);
		foreach (string path in files)
		{
			if (TryLoad(out var instance, path))
			{
				savesToMigrate.Add(instance);
			}
		}
	}

	public static int ReturnSaveRequiredMigrationAmount()
	{
		Initialize();
		return _savesToMigrate.Count;
	}

	public static int MigrateFiles()
	{
		Initialize();
		int result = MigrateFiles(_savesToMigrate);
		Extensions.TryDeleteDirectory(OLD_AUTOSAVES_DIRECTORY);
		Session.Profile.OnSaveFilesMigrated();
		new GameEvent(GameEventType.SavesMigrated).Dispatch();
		Settings.Instance.HasMigratedSaves = true;
		Settings.Instance.Save();
		return result;
	}

	private static int MigrateFiles(List<SaveMetaInfo> savesToMigrate)
	{
		int num = 0;
		foreach (SaveMetaInfo item in savesToMigrate)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(item.Path);
				if (!SaveMetaInfo.TryReturnDirectory(item.CommunityName, item.Type, out var directory))
				{
					Directory.CreateDirectory(directory);
				}
				directory += fileInfo.Name;
				if (File.Exists(directory))
				{
					Debug.LogErrorFormat("Unable to Migrate '{0}' to '{1}' because a file already exists at that path.", item.Path, directory);
				}
				else
				{
					File.Move(item.Path, directory);
					num++;
				}
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("Unable to Migrate '{0}' because of exception '{1}'.", item.Path, ex.Message);
			}
		}
		return num;
	}

	private static bool TryLoad(out SaveMetaInfo instance, string path)
	{
		if (File.Exists(path) && SaveMetaInfo.TryDeserialize(path, File.ReadAllBytes(path), out instance))
		{
			return true;
		}
		Debug.LogException(new Exception("Unable to load SaveMetaInfo for migartion: '" + path + "'"));
		instance = null;
		return false;
	}

	public static bool ReturnRequiresMigration()
	{
		if (Settings.Instance.HasMigratedSaves)
		{
			return false;
		}
		Initialize();
		return 0 < _savesToMigrate.Count;
	}
}
