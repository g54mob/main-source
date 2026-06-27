using System;
using System.IO;
using System.Threading.Tasks;
using Restory.Data.Achievements;
using Restory.Data.ReadWriteServices;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Achievements
{
	public class AchievementsDataSaveLoadSystem : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private string achievementsFileName = "achievements";

		[SerializeField]
		private SaveSystemSettings settings;

		private AchievementsManager achievementsManager;

		private IReadWriteDataService readWriteDataService;

		private PlayerProfileService profileService;

		private PlayerProfileChangeObserver playerProfileChangeObserver;

		private bool isSaving;

		private int saveQueued;

		private string AchievementsFileNameWithExt => achievementsFileName + ".json";

		[Inject]
		private void Construct(AchievementsManager achievementsManager, IReadWriteDataService readWriteDataService, PlayerProfileService profileService, PlayerProfileChangeObserver playerProfileChangeObserver)
		{
			this.achievementsManager = achievementsManager;
			this.readWriteDataService = readWriteDataService;
			this.profileService = profileService;
			this.playerProfileChangeObserver = playerProfileChangeObserver;
			achievementsManager.AchievementProgressChanged += AchievementsManager_AchievementProgressChanged;
			playerProfileChangeObserver.AddSubscriber(this, ResolveOnProfileChanged);
		}

		public void Dispose()
		{
			if (achievementsManager != null)
			{
				achievementsManager.AchievementProgressChanged -= AchievementsManager_AchievementProgressChanged;
			}
			playerProfileChangeObserver?.RemoveSubscriber(this);
		}

		public async void Load()
		{
			AchievementsManagerSaveData saveData = await LoadAchievementsData();
			achievementsManager.SetSaveData(saveData);
		}

		public void Save()
		{
			Debug.Log($"SaveAchievementsData Profile = {profileService.CurrentProfile}");
			AchievementsManagerSaveData saveData = achievementsManager.GetSaveData();
			SaveAchievementsData(saveData);
		}

		public void DeleteAchievements(int profile)
		{
			string profilePath = GetProfilePath(profile, AchievementsFileNameWithExt);
			readWriteDataService.DeleteFile(profilePath);
		}

		private async Task<AchievementsManagerSaveData> LoadAchievementsData()
		{
			Debug.Log($"LoadAchievementsData Profile = {profileService.CurrentProfile}");
			string currentProfilePath = GetCurrentProfilePath(AchievementsFileNameWithExt);
			return await readWriteDataService.ReadDataAsync<AchievementsManagerSaveData>(currentProfilePath, FileType.Achievements);
		}

		private async void SaveAchievementsData(AchievementsManagerSaveData achievementsData)
		{
			if (isSaving)
			{
				saveQueued++;
				return;
			}
			isSaving = true;
			try
			{
				string currentProfilePath = GetCurrentProfilePath(AchievementsFileNameWithExt);
				await readWriteDataService.WriteDataAsync(currentProfilePath, achievementsData, FileType.Achievements);
			}
			catch (Exception)
			{
			}
			finally
			{
				isSaving = false;
				if (saveQueued > 0)
				{
					saveQueued--;
					Save();
				}
			}
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

		private void AchievementsManager_AchievementProgressChanged(Achievement achievement)
		{
			Save();
		}

		private void ResolveOnProfileChanged()
		{
			Load();
		}
	}
}
