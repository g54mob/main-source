using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace M4.Session
{
	public class DefaultUser : IUser
	{
		private static readonly string PERSISTENT_DATA_PATH = Path.GetFullPath(Application.persistentDataPath + Path.DirectorySeparatorChar);

		public int Id => -1;

		public string Name => "DefaultPlayer";

		public void Initialize(IUserEventHandler event_handler)
		{
			event_handler.OnUserEvent(this, UserEventType.INITIALIZATION_COMPLETE);
		}

		public void RequestSignIn()
		{
		}

		public void ProcessGameEvent(IRun run, GameEvent game_event)
		{
		}

		public void LoadPlayerRuns(PlayerProfile profile, UnityAction result_callback)
		{
			DefaultLoadPlayerRuns(profile, result_callback);
		}

		public static void DefaultLoadPlayerRuns(PlayerProfile profile, UnityAction result_callback)
		{
			List<SaveMetaInfo> saveMetaInfos = new List<SaveMetaInfo>();
			LoadPlayerRunsInDirectory(profile, saveMetaInfos, SaveInfo.PLAYER_SAVES_DIRECTORY);
			if (Application.isEditor)
			{
				LoadPlayerRunsInDirectory(profile, saveMetaInfos, SaveInfo.EDITOR_SAVES_DIRECTORY);
			}
			result_callback();
		}

		private static void LoadPlayerRunsInDirectory(PlayerProfile profile, List<SaveMetaInfo> saveMetaInfos, string saveRoot)
		{
			if (!Directory.Exists(saveRoot))
			{
				return;
			}
			string[] directories = Directory.GetDirectories(saveRoot);
			foreach (string text in directories)
			{
				string fileName = Path.GetFileName(text);
				if (TryLoadSaveMetaInfos(saveMetaInfos, text, Path.GetFullPath(text + "/Autosaves/")))
				{
					profile.OnPlayerRunLoaded(fileName, saveMetaInfos, saveRoot);
				}
			}
		}

		private static bool TryLoadSaveMetaInfos(List<SaveMetaInfo> saveMetaInfos, params string[] directories)
		{
			saveMetaInfos.Clear();
			using PooledList<string> pooledList = PooledList<string>.Get();
			foreach (string path in directories)
			{
				if (Directory.Exists(path))
				{
					pooledList.AddRange(Directory.GetFiles(path, "*.fs"));
					pooledList.AddRange(Directory.GetFiles(path, "*.smi"));
				}
			}
			if (pooledList.Count == 0)
			{
				return false;
			}
			foreach (string item in pooledList)
			{
				if (File.Exists(item) && SaveMetaInfo.TryDeserialize(item, File.ReadAllBytes(item), out var instance))
				{
					saveMetaInfos.Add(instance);
				}
				else
				{
					Debug.LogException(new Exception("Unable to load file: " + item));
				}
			}
			return 0 < pooledList.Count;
		}

		public void LoadFile(string filename, UnityAction<StorageActionResult> result_callback)
		{
			string path = (Path.IsPathRooted(filename) ? filename : (PERSISTENT_DATA_PATH + filename));
			if (File.Exists(path))
			{
				result_callback(new StorageActionResult(filename, succes: true, File.ReadAllBytes(path)));
			}
			else
			{
				result_callback(new StorageActionResult(filename, succes: false));
			}
		}

		public void SaveFile(string filename, byte[] data, UnityAction<StorageActionResult> result_callback)
		{
			DefaultSaveFile(filename, data, result_callback);
		}

		public static void DefaultSaveFile(string filename, byte[] data, UnityAction<StorageActionResult> result_callback = null)
		{
			string text = (Path.IsPathRooted(filename) ? filename : (PERSISTENT_DATA_PATH + filename));
			string directoryName = Path.GetDirectoryName(text);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
				Debug.Log("Directory '" + directoryName + "' was created to save '" + Path.GetFileName(filename) + "'");
			}
			File.WriteAllBytes(text, data);
			result_callback?.Invoke(new StorageActionResult(text, succes: true));
		}

		public void RemoveFile(string filename, UnityAction<StorageActionResult> result_callback = null)
		{
			string path = (Path.IsPathRooted(filename) ? filename : (PERSISTENT_DATA_PATH + filename));
			bool succes = false;
			if (File.Exists(path))
			{
				File.Delete(path);
				succes = true;
			}
			result_callback?.Invoke(new StorageActionResult(filename, succes));
		}

		public bool IsAchievementUnlocked(AchievementId achievement_id)
		{
			return false;
		}

		public void UnlockAchievement(AchievementBase achievement)
		{
			GameManager.UIManager.DisplayPanel(achievement);
		}

		public void Dispose()
		{
		}

		public bool OwnsDLC(PlatformId platform)
		{
			return true;
		}
	}
}
