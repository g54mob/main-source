using System;
using System.IO;
using System.Threading.Tasks;
using Restory.Data.ReadWriteServices;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameSettings
{
	public class GameSettingsDataSaveLoadSystem : MonoBehaviour, IDisposable
	{
		private const string INPUT_DATA_FILE_NAME = "inputSettings.json";

		[SerializeField]
		private string gameSettingsFileName = "gameSettings";

		[SerializeField]
		private SaveSystemSettings settings;

		private GameSettingsManager gameSettings;

		private IReadWriteDataService readWriteDataService;

		private PlayerProfileService profileService;

		private PlayerProfileChangeObserver playerProfileChangeObserver;

		private string GameSettingsFileNameWithExt => gameSettingsFileName + ".json";

		[Inject]
		private void Construct(GameSettingsManager gameSettings, IReadWriteDataService readWriteDataService, PlayerProfileService profileService, PlayerProfileChangeObserver playerProfileChangeObserver)
		{
			this.gameSettings = gameSettings;
			this.readWriteDataService = readWriteDataService;
			this.profileService = profileService;
			this.playerProfileChangeObserver = playerProfileChangeObserver;
			playerProfileChangeObserver.AddSubscriber(this, OnProfileChanged);
		}

		public void Dispose()
		{
			playerProfileChangeObserver?.RemoveSubscriber(this);
		}

		private void OnProfileChanged()
		{
			UpdateGameSettingsData();
		}

		private async void UpdateGameSettingsData()
		{
			GameSettingsManager.GameSettingsData_V3 data = await LoadGameSettingsData();
			gameSettings.Initialize(data);
		}

		public void Save()
		{
			SaveGameSettingsData(gameSettings.Data);
		}

		private async Task<GameSettingsManager.GameSettingsData_V3> LoadGameSettingsData()
		{
			string currentProfilePath = GetCurrentProfilePath(GameSettingsFileNameWithExt);
			return await readWriteDataService.ReadDataAsync<GameSettingsManager.GameSettingsData_V3>(currentProfilePath, FileType.GameSettings);
		}

		private async void SaveGameSettingsData(GameSettingsManager.GameSettingsData_V3 settingsData)
		{
			string currentProfilePath = GetCurrentProfilePath(GameSettingsFileNameWithExt);
			await readWriteDataService.WriteDataAsync(currentProfilePath, settingsData, FileType.GameSettings);
		}

		public async Task<T> LoadInputUserData<T>() where T : class
		{
			string path = GetCurrentProfilePath("inputSettings.json");
			T obj = await readWriteDataService.ReadDataAsync<T>(path, FileType.InputSettings);
			if (obj == null)
			{
				readWriteDataService.DeleteFile(path);
			}
			return obj;
		}

		public async Task SaveInputUserData<T>(T data) where T : class
		{
			string currentProfilePath = GetCurrentProfilePath("inputSettings.json");
			await readWriteDataService.WriteDataAsync(currentProfilePath, data, FileType.InputSettings);
		}

		public void DeleteGameSettings(int profile)
		{
			string profilePath = GetProfilePath(profile, GameSettingsFileNameWithExt);
			readWriteDataService.DeleteFile(profilePath);
		}

		public void DeleteInputSettings(int profile)
		{
			string profilePath = GetProfilePath(profile, "inputSettings.json");
			readWriteDataService.DeleteFile(profilePath);
		}

		private string GetCurrentProfilePath(string fileName)
		{
			return GetProfilePath(profileService.CurrentProfile, fileName);
		}

		private string GetProfilePath(int profile, string fileName)
		{
			string path = $"Profile{profile}.{fileName}";
			return Path.Combine(settings.WorkDirectory, path);
		}
	}
}
