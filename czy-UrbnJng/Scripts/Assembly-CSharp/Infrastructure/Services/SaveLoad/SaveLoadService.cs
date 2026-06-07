using System;
using System.IO;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Newtonsoft.Json;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
	public class SaveLoadService : ISaveLoadService, IService
	{
		private const string RELATIVE_PATH = "/player-progress.json";

		private readonly IPersistentProgressService _progressService;

		private readonly IGameFactory _gameFactory;

		private string path;

		public string Version { get; }

		public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
		{
			_progressService = progressService;
			_gameFactory = gameFactory;
			path = Application.persistentDataPath + "/player-progress.json";
			Version = "0.68";
		}

		public void SaveProgress()
		{
			foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
			{
				progressWriter.UpdateProgress(_progressService.Progress);
			}
			SaveData(_progressService.Progress);
		}

		public PlayerProgress LoadProgress()
		{
			if (!File.Exists(path))
			{
				return null;
			}
			PlayerProgress playerProgress = LoadData<PlayerProgress>();
			if (playerProgress == null)
			{
				return null;
			}
			if (!(playerProgress.version != Version))
			{
				return playerProgress;
			}
			return null;
		}

		private void UpgradeProgress(ref PlayerProgress progress)
		{
			progress.version = Version;
		}

		private bool SaveData<TProgressData>(TProgressData progressData)
		{
			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
					using FileStream fileStream = File.Create(path);
					fileStream.Close();
					File.WriteAllText(path, JsonConvert.SerializeObject(progressData));
					return true;
				}
				catch (Exception ex)
				{
					Debug.Log("Unable to save data due to: " + ex.Message + " " + ex.StackTrace);
					return false;
				}
			}
			try
			{
				using FileStream fileStream2 = File.Create(path);
				fileStream2.Close();
				File.WriteAllText(path, JsonConvert.SerializeObject(progressData));
				return true;
			}
			catch (Exception ex2)
			{
				Debug.Log("Unable to save data due to: " + ex2.Message + " " + ex2.StackTrace);
				return false;
			}
		}

		private TProgressData LoadData<TProgressData>()
		{
			try
			{
				return JsonConvert.DeserializeObject<TProgressData>(File.ReadAllText(path));
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to load data due to: " + ex.Message + " " + ex.StackTrace);
				throw ex;
			}
		}
	}
}
