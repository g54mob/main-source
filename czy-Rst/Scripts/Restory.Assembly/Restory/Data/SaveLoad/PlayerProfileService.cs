using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Restory.Data.Locations;
using Restory.Data.Profiles;
using Restory.Data.ReadWriteServices;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad.Containers;
using UnityEngine;
using Zenject;

namespace Restory.Data.SaveLoad
{
	public class PlayerProfileService : MonoBehaviour, IInitializable
	{
		[Serializable]
		private class CurrentProfileData
		{
			public int Profile = 1;
		}

		[SerializeField]
		private SaveSystemSettings settings;

		[SerializeField]
		private ProfilesInfo profilesInfo;

		public const int MAX_PROFILES_COUNT = 3;

		private readonly List<ProfileData> profilesData = new List<ProfileData>();

		private const int DefaultProfile = 1;

		private const string CurrentProfileFile = "CurrentProfileIndex";

		private const string ProfileDataFile = "ProfileData";

		private IReadWriteDataService readWriteDataService;

		private IGameplayReadOnlyDataService gameplayReadOnlyDataService;

		public ProfilesInfo ProfilesInfo => profilesInfo;

		public int CurrentProfile { get; private set; } = 1;

		public event Action OnProfileChanged = delegate
		{
		};

		[Inject]
		private void Construct(IReadWriteDataService readWriteDataService, IGameplayReadOnlyDataService gameplayReadOnlyDataService)
		{
			this.readWriteDataService = readWriteDataService;
			this.gameplayReadOnlyDataService = gameplayReadOnlyDataService;
		}

		public void Initialize()
		{
			LoadData();
		}

		private async void LoadData()
		{
			await LoadProfilesData();
			string currentProfileFilePath = GetCurrentProfileFilePath();
			if (!readWriteDataService.IsFileExists(currentProfileFilePath))
			{
				CurrentProfile = 1;
				this.OnProfileChanged();
			}
			else
			{
				CurrentProfile = (await readWriteDataService.ReadDataAsync<CurrentProfileData>(currentProfileFilePath, FileType.CurrentProfileIndex)).Profile;
				this.OnProfileChanged();
			}
		}

		private async Task LoadProfilesData()
		{
			profilesData.Clear();
			for (int i = 0; i < 3; i++)
			{
				int index = i + 1;
				ProfileData profileData = await LoadProfileData(index);
				if (profileData == null)
				{
					profileData = CreateDefaultProfileData();
				}
				profilesData.Add(profileData);
			}
		}

		public bool GameProgressExists()
		{
			return GameProgressExists(CurrentProfile);
		}

		public bool GameProgressExists(int profileIndex)
		{
			SaveFileNameParameters parameters = new SaveFileNameParameters(GameMode.Story, profileIndex);
			return readWriteDataService.SaveFileExists(parameters);
		}

		public void BackupSaveData()
		{
			readWriteDataService.BackupSaveDataDirectory();
		}

		public void DeleteGameProgress(int index)
		{
			SaveFileNameParameters parameters = new SaveFileNameParameters(GameMode.Story, index);
			readWriteDataService.DeleteAll(parameters);
		}

		public async void SetCurrentProfile(int profile)
		{
			CurrentProfile = profile;
			await SaveCurrentProfile();
			this.OnProfileChanged();
		}

		private Task SaveCurrentProfile()
		{
			string currentProfileFilePath = GetCurrentProfileFilePath();
			CurrentProfileData data = new CurrentProfileData
			{
				Profile = CurrentProfile
			};
			return readWriteDataService.WriteDataAsync(currentProfileFilePath, data, FileType.CurrentProfileIndex);
		}

		private string GetCurrentProfileFilePath()
		{
			return Path.Combine(settings.WorkDirectory, "CurrentProfileIndex.json");
		}

		private async Task<ProfileData> LoadProfileData(int index)
		{
			string profileDataPath = GetProfileDataPath(index);
			return await readWriteDataService.ReadDataAsync<ProfileData>(profileDataPath, FileType.CurrentProfileIndex);
		}

		public ProfileData GetCurrentProfileData()
		{
			return GetProfileData(CurrentProfile);
		}

		public ProfileData GetProfileData(int index)
		{
			int num = index - 1;
			if (num < 0 || num >= profilesData.Count)
			{
				Debug.LogError($"<color=red>Wrong index: {index}</color>");
				return null;
			}
			return profilesData[num];
		}

		private void UpdateProfileData(int index, ProfileData data)
		{
			int num = index - 1;
			if (num >= 0 && num < profilesData.Count)
			{
				profilesData[num] = new ProfileData
				{
					IconId = data.IconId,
					CharacterSelected = data.CharacterSelected
				};
			}
		}

		public Sprite GetProfileIcon(string iconId)
		{
			ProfileIcon profileIcon = ProfilesInfo.ProfilesIcons.FirstOrDefault((ProfileIcon x) => string.Equals(x.Id, iconId, StringComparison.Ordinal));
			if (profileIcon == null)
			{
				Debug.LogWarning("Failed to find icon with id " + iconId);
				profileIcon = ProfilesInfo.ProfilesIcons.First();
			}
			return profileIcon.Icon;
		}

		public Task SaveProfileData(int index, ProfileData data)
		{
			UpdateProfileData(index, data);
			string profileDataPath = GetProfileDataPath(index);
			return readWriteDataService.WriteDataAsync(profileDataPath, data, FileType.CurrentProfileIndex);
		}

		public void DeleteProfileData(int index)
		{
			UpdateProfileData(index, CreateDefaultProfileData());
			string profileDataPath = GetProfileDataPath(index);
			readWriteDataService.DeleteFile(profileDataPath);
			this.OnProfileChanged();
		}

		private ProfileData CreateDefaultProfileData()
		{
			return new ProfileData
			{
				IconId = profilesInfo.ProfilesIcons.First().Id,
				CharacterSelected = false
			};
		}

		private string GetProfileDataPath(int index)
		{
			return Path.Combine(settings.WorkDirectory, string.Format("{0} {1}.json", "ProfileData", index));
		}

		public async Task<SaveSystemSaveData> GetLatestGameProgress()
		{
			return await GetLatestGameProgress(CurrentProfile, GameMode.Story);
		}

		public async Task<SaveSystemSaveData> GetLatestGameProgress(int index)
		{
			return await GetLatestGameProgress(index, GameMode.Story);
		}

		private async Task<SaveSystemSaveData> GetLatestGameProgress(int index, GameMode gameMode)
		{
			SaveFileNameParameters parameters = new SaveFileNameParameters(gameMode, index);
			return await gameplayReadOnlyDataService.ReadLastGameProgressAsync<SaveSystemSaveData>(parameters);
		}
	}
}
