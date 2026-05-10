using System;
using CTS.Core;
using CTS.ScriptableSettings;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace CTS
{
	public class ProfileManager : CTSSingleton<ProfileManager>, ILockable
	{
		[SerializeField]
		private SaveManager _sceneSave;

		[SerializeField]
		private SaveManager _profileSave;

		[SerializeField]
		private SettingObject<string> _currentProfileSetting;

		[SerializeField]
		private SettingObject<bool> _autoSaveSetting;

		[field: SerializeField]
		public AssetReferences AssetReferences { get; private set; }

		public Profile CurrentProfile { get; private set; }

		public bool IsSaveLocked => ObjectLock.IsLocked();

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public static event Action<Profile> ProfileChanged;

		public static event Action Saving;

		public static event Action Saved;

		protected override void SingletonAwake()
		{
			Application.wantsToQuit += ApplicationWantsToQuit;
			AssetReferences.Add(AssetReferences);
		}

		private void Start()
		{
			string text = SceneManager.GetActiveScene().name;
			if (text.Contains("Menu", StringComparison.InvariantCulture) || text.Contains("Startup", StringComparison.InvariantCulture))
			{
				LoadCurrentProfile();
			}
		}

		private bool ApplicationWantsToQuit()
		{
			if (_autoSaveSetting.GetValue())
			{
				Save();
			}
			return true;
		}

		protected override void OnSingletonDestroy()
		{
			Application.wantsToQuit -= ApplicationWantsToQuit;
		}

		public void Save()
		{
			if (!IsSaveLocked && CurrentProfile != null)
			{
				string text = CurrentProfile.GetName();
				_currentProfileSetting.SetValue(text);
				ProfileManager.Saving?.Invoke();
				if (CTSSingleton<GameMode>.TryGetInstance(out var outInstance))
				{
					_sceneSave.Save(text + "/" + outInstance.LevelInfo.name);
				}
				_profileSave.Save(text + "/profile");
				ProfileManager.Saved?.Invoke();
			}
		}

		public void SaveProfile()
		{
			if (CurrentProfile != null)
			{
				string text = CurrentProfile.GetName();
				_currentProfileSetting.SetValue(text);
				ProfileManager.Saving?.Invoke();
				_profileSave.Save(text + "/profile");
				ProfileManager.Saved?.Invoke();
			}
		}

		public bool LoadCurrentProfile()
		{
			string text = ((CurrentProfile != null) ? CurrentProfile.GetName() : _currentProfileSetting.GetValue());
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			return LoadProfile(text);
		}

		public bool IsCurrentProfile(string profileName)
		{
			string text = ((CurrentProfile != null) ? CurrentProfile.GetName() : _currentProfileSetting.GetValue());
			return text == profileName;
		}

		public bool LoadProfile(string profileName)
		{
			return _profileSave.Load(profileName + "/profile");
		}

		public bool ProfileExists(string profileName)
		{
			return ES3.FileExists("Saves/" + profileName + "/profile.sav");
		}

		public void RestartScene(MapInfoSO map, EGameMode gameMode)
		{
			LoadScene(map.SceneToLoad, null, gameMode);
		}

		public void LoadScene(MapInfoSO map, EGameMode gameMode)
		{
			LoadScene(map.SceneToLoad, map.name, gameMode);
		}

		private void LoadScene(SceneReference scene, string saveName, EGameMode gameMode)
		{
			GameMode.StartMode = gameMode;
			GameMode.SaveToLoad = saveName;
			if (MonoSingleton<MenusManager>.TryGetInstance(out var outInstance))
			{
				outInstance.SwitchScene(scene);
			}
			else
			{
				Addressables.LoadSceneAsync(scene.Address);
			}
		}

		public bool LoadSceneSave(string sceneName)
		{
			return _sceneSave.Load(CurrentProfile.GetName() + "/" + sceneName);
		}

		public void SetNewProfile(Profile profile)
		{
			if (CurrentProfile != profile)
			{
				profile.BackupAndClear();
				_profileSave.Clear();
				SetCurrentProfile(profile);
			}
		}

		public void SetCurrentProfile(Profile profile)
		{
			if (CurrentProfile != profile)
			{
				CurrentProfile = profile;
				ProfileManager.ProfileChanged?.Invoke(CurrentProfile);
			}
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
