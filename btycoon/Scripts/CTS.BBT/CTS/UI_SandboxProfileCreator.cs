using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_SandboxProfileCreator : UI_Manager<UI_SandboxProfileCreator>
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private UI_SandboxProfile _currentProfile;

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private IResettableSetting[] _settings = Array.Empty<IResettableSetting>();

		private FreemodeProfile _profile = new FreemodeProfile("dummy");

		public DifficultyData DifficultyData
		{
			get
			{
				if (!_profile.DifficultyData)
				{
					_profile.DifficultyData = ScriptableObject.CreateInstance<DifficultyData>();
				}
				return _profile.DifficultyData;
			}
		}

		public LevelSettingsList Settings
		{
			get
			{
				if (!_profile.Settings)
				{
					_profile.Settings = ScriptableObject.CreateInstance<LevelSettingsList>();
				}
				return _profile.Settings;
			}
		}

		public MapInfoSO MapInfoSO
		{
			get
			{
				return _profile.MapInfo;
			}
			set
			{
				_profile.MapInfo = value;
			}
		}

		public FreemodeProfile CreateProfile(string profileName)
		{
			return new FreemodeProfile(profileName)
			{
				DifficultyData = DifficultyData,
				Settings = Settings,
				MapInfo = MapInfoSO
			};
		}

		public void CreateAndPlayProfile()
		{
			if (!(_currentProfile.CurrentProfile == null))
			{
				FreemodeProfile freemodeProfile = CreateProfile(_currentProfile.CurrentProfile.ProfileName);
				CTSSingleton<ProfileManager>.Instance.SetNewProfile(freemodeProfile);
				UnlockingManager.AddUnlockKey((EUnlockKey)(-1));
				CTSSingleton<ProfileManager>.Instance.SaveProfile();
				freemodeProfile.PlayProfile();
			}
		}

		public void ResetSettings()
		{
			IResettableSetting[] settings = _settings;
			for (int i = 0; i < settings.Length; i++)
			{
				settings[i].ResetValue();
			}
		}
	}
}
