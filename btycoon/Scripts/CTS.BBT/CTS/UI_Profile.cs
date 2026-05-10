using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_Profile : CTSBehaviour, ICareerProfileReference, IRepaint
	{
		[SerializeField]
		private GameObject _profileObject;

		[SerializeField]
		private GameObject _newGameObject;

		[SerializeField]
		private GameObject _deleteObject;

		[SerializeField]
		private MapInfoSO[] _defaultUnlockedMaps;

		[InjectScope(EGetScope.ChildrenExclusive)]
		[Inject(false)]
		private UI_ProfileFeature[] _features;

		private CareerMetaData? _profileData;

		private MapInfoSO _lastLevelPlayed;

		private string _profileName;

		private string _profileSaveName;

		[field: SerializeField]
		public int ProfileIndex { get; set; }

		public static int CurrentProfileIndex { get; private set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			_profileName = CareerProfile.GetProfileName(ProfileIndex);
			_profileSaveName = _profileName + "/profile";
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Repaint();
		}

		public void ClearProfile()
		{
			Profile.BackupAndClearProfile(_profileName);
		}

		public void ShowDeletePanel(bool isShown)
		{
			if (isShown)
			{
				_deleteObject.SetActive(value: true);
				_profileObject.SetActive(value: false);
				_newGameObject.SetActive(value: false);
			}
			else
			{
				Repaint();
			}
		}

		public void PlayProfile()
		{
			if (CTSSingleton<ProfileManager>.Instance.LoadProfile(_profileName))
			{
				CTSSingleton<ProfileManager>.Instance.CurrentProfile.PlayProfile();
			}
		}

		public void SetCurrentIndex()
		{
			CurrentProfileIndex = ProfileIndex;
		}

		public void NewGame()
		{
			CareerProfile careerProfile = new CareerProfile
			{
				ProfileIndex = ProfileIndex
			};
			MapInfoSO[] defaultUnlockedMaps = _defaultUnlockedMaps;
			foreach (MapInfoSO level in defaultUnlockedMaps)
			{
				careerProfile.Unlock(level);
			}
			CTSSingleton<ProfileManager>.Instance.SetNewProfile(careerProfile);
			careerProfile.PlayProfile();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			ClearProfileData();
		}

		public void ClearProfileData()
		{
			_profileData = null;
		}

		public bool IsCurrentProfile()
		{
			return CTSSingleton<ProfileManager>.Instance.IsCurrentProfile(_profileName);
		}

		public bool HasProfile()
		{
			return CTSSingleton<ProfileManager>.Instance.ProfileExists(_profileName);
		}

		public CareerMetaData GetProfile()
		{
			if (!_profileData.HasValue)
			{
				ES3Settings globalFolderSettings = SaveSettings.GetGlobalFolderSettings(_profileSaveName);
				_profileData = ES3.Load("CareerMeta", default(CareerMetaData), globalFolderSettings);
			}
			return _profileData.Value;
		}

		public MapInfoSO GetLastLevelPlayed()
		{
			ES3Settings globalFolderSettings = SaveSettings.GetGlobalFolderSettings(_profileSaveName);
			if (!ES3.FileExists(globalFolderSettings))
			{
				return null;
			}
			if (!ES3.KeyExists("LastLevelPlayed", globalFolderSettings))
			{
				return null;
			}
			return ES3.Load<AssetRef<MapInfoSO>>("LastLevelPlayed", globalFolderSettings).Asset;
		}

		public void Repaint()
		{
			_deleteObject.SetActive(value: false);
			if (HasProfile())
			{
				_newGameObject.SetActive(value: false);
				_profileObject.SetActive(value: true);
			}
			else
			{
				_newGameObject.SetActive(value: true);
				_profileObject.SetActive(value: false);
			}
			UI_ProfileFeature[] features = _features;
			for (int i = 0; i < features.Length; i++)
			{
				features[i].Repaint();
			}
		}
	}
}
