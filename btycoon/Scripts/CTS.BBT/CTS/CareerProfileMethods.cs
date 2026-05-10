using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Static Behaviours/Career Profile Behaviour")]
	public class CareerProfileMethods : ScriptableObject
	{
		[SerializeField]
		private MapInfoSO[] _unlockedMaps;

		[Header("Debug")]
		[SerializeField]
		private MapInfoSO _unlockMap;

		[Button(null, EButtonEnableMode.Always)]
		private void UnlockLevel()
		{
			UnlockLevel(_unlockMap);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void SetMaxScoreForLevel()
		{
			if ((object)_unlockMap != null)
			{
				_unlockMap.SetScoreInProfile(6);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AddStarForLevel()
		{
			if ((object)_unlockMap != null)
			{
				_unlockMap.SetScoreInProfile(_unlockMap.GetScoreInProfile() + 2);
			}
		}

		public void CreateNewProfile()
		{
			CareerProfile careerProfile = new CareerProfile();
			MapInfoSO[] unlockedMaps = _unlockedMaps;
			foreach (MapInfoSO level in unlockedMaps)
			{
				careerProfile.Unlock(level);
			}
			CTSSingleton<ProfileManager>.Instance.SetNewProfile(careerProfile);
		}

		public void ClearProfile(int index)
		{
			Profile.BackupAndClearProfile("Story_" + index.ToString("D3"));
		}

		public void LoadProfile(string profileName)
		{
			CTSSingleton<ProfileManager>.Instance.LoadProfile(profileName);
			PlayCurrentProfile();
		}

		public void PlayCurrentProfile()
		{
			CTSSingleton<ProfileManager>.Instance.CurrentProfile?.PlayProfile();
		}

		public void UnlockLevel(MapInfoSO level)
		{
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile careerProfile)
			{
				careerProfile.Unlock(level);
			}
		}

		public void ReloadCurrentMap()
		{
			if (CTSSingleton<GameMode>.TryGetInstance(out var outInstance))
			{
				CTSSingleton<ProfileManager>.Instance.LoadScene(outInstance.LevelInfo, outInstance.CurrentMode);
			}
		}

		public void SaveProgress()
		{
			CTSSingleton<ProfileManager>.Instance.Save();
		}
	}
}
