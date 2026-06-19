using System;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MapPinHospital : MapPin
	{
		[SerializeField]
		private SharedInstance_TH20TH20_LevelConfig _levelConfig;

		[SerializeField]
		private MeshRenderer _meshIcon;

		[SerializeField]
		private Material _materialDefault;

		[SerializeField]
		private Material _materialHighlighted;

		[SerializeField]
		private Material _materialLocked;

		[SerializeField]
		private Material _materialLockedHighlighted;

		[SerializeField]
		private Material _materialDefaultRemix;

		[SerializeField]
		private Material _materialHighlightedRemix;

		[SerializeField]
		private Material _materialLockedRemix;

		[SerializeField]
		private Material _materialLockedHighlightedRemix;

		[SerializeField]
		private GameObject[] _stars;

		[SerializeField]
		private MeshRenderer _remixBadgeIcon;

		[SerializeField]
		private GameObject _hasSaveIcon;

		[SerializeField]
		private GameObject _inProgressIcon;

		[SerializeField]
		private UnseenNotificationsIcon _unseenNotificationsIcon;

		[SerializeField]
		private MetagameHospitalVisual _metagameHospitalVisual;

		[SerializeField]
		private GameObject _activeHospitalEffectPrefab;

		private Metagame _metagame;

		private MetagameMap _metagameMap;

		private SaveSystem _saveSystem;

		private MetagameHospitalRecord _hospitalRecord;

		private HUD _hud;

		private bool _cursorOver;

		private GameObject _activeHospitalEffect;

		private bool _isDlcUnlocked;

		private LevelConfig _remixLevel;

		private const string AudioEventNameOnSelected = "PopOut3:UI";

		public MetagameHospitalVisual HospitalVisual => _metagameHospitalVisual;

		public LevelConfig LevelConfig
		{
			get
			{
				if (!(_levelConfig != null))
				{
					return null;
				}
				return _levelConfig.Instance;
			}
		}

		public void Initialise(Metagame metagame, MetagameMap metagameMap, SaveSystem saveSystem)
		{
			_metagame = metagame;
			_metagameMap = metagameMap;
			_saveSystem = saveSystem;
			_hud = metagameMap.HUD;
			_hospitalRecord = metagame.GetHospitalRecord(LevelConfig);
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(TooltipFunction);
			}
			if (base.CutsceneLocation != null)
			{
				_metagameMap.CutsceneManager.RegisterCutsceneLocation(base.CutsceneLocation);
			}
			if (_metagameHospitalVisual != null)
			{
				_metagameMap.CutsceneManager.RegisterCutsceneAnimatable(_metagameHospitalVisual);
			}
			OnlineMetadataManager onlineMetadataManager = _metagame.OnlineMetadataManager;
			onlineMetadataManager.OnLatestData = (Action)Delegate.Combine(onlineMetadataManager.OnLatestData, new Action(OnMetadataReceived));
			_remixLevel = GetRemixLevel(_levelConfig.Instance);
			Refresh();
			RefreshVisual();
		}

		public override void PrepareForDestroy()
		{
			OnlineMetadataManager onlineMetadataManager = _metagame.OnlineMetadataManager;
			onlineMetadataManager.OnLatestData = (Action)Delegate.Remove(onlineMetadataManager.OnLatestData, new Action(OnMetadataReceived));
			GameObjectUtils.SafeDestroy(ref _activeHospitalEffect);
		}

		private void TooltipFunction(Tooltip tooltip)
		{
			TooltipHospitalPin tooltipHospitalPin = tooltip as TooltipHospitalPin;
			if (!(tooltipHospitalPin == null) && (_hospitalRecord.IsVisible() || _levelConfig.Instance.IsVisible(_metagame)))
			{
				tooltipHospitalPin.Setup(LevelConfig, _hospitalRecord, _metagame, _saveSystem);
			}
		}

		private bool IsPlayingThisLevel()
		{
			if (_metagame.CurrentLevel != null)
			{
				return _metagame.CurrentLevel.Config == LevelConfig;
			}
			return _metagame.LastPlayedLevelID == LevelConfig.UniqueId;
		}

		private bool SaveIsPresentForThisLevel()
		{
			return _saveSystem.GetSaveForLevel(LevelConfig.UniqueId) != null;
		}

		public override void OnSelected()
		{
			base.OnSelected();
			AudioManager.Instance.Play("PopOut3:UI");
			SelectedWaypointMenu selectedWaypointMenu = _hud.FindMenu<SelectedWaypointMenu>();
			if (selectedWaypointMenu != null)
			{
				selectedWaypointMenu.CloseMenu();
			}
			SelectedHospitalMenu selectedHospitalMenu = _hud.FindMenu<SelectedHospitalMenu>();
			if (selectedHospitalMenu == null)
			{
				selectedHospitalMenu = _hud.CreateMenu<SelectedHospitalMenu>();
			}
			selectedHospitalMenu.OpenMenu();
			selectedHospitalMenu.Setup(LevelConfig, _hospitalRecord, _metagame.OnlineMetadataManager, _metagameMap, _saveSystem);
		}

		public override void OnCursorOver(bool over)
		{
			base.OnCursorOver(over);
			_cursorOver = over;
			RefreshMaterial();
		}

		public override void OnUnselected()
		{
			base.OnUnselected();
			SelectedHospitalMenu selectedHospitalMenu = _hud.FindMenu<SelectedHospitalMenu>(includeInactive: false);
			if (selectedHospitalMenu != null)
			{
				selectedHospitalMenu.CloseMenu();
			}
		}

		private bool RefreshMaterial()
		{
			if (!_isDlcUnlocked)
			{
				_meshIcon.material = (_cursorOver ? _materialLockedHighlighted : _materialLocked);
				return false;
			}
			if (_metagame == null)
			{
				return false;
			}
			if (_hospitalRecord == null)
			{
				return false;
			}
			_remixLevel = GetRemixLevel(_levelConfig.Instance);
			bool flag = _remixLevel != null && _remixLevel.IsVisible(_metagame);
			if (_hospitalRecord.IsVisible() || _levelConfig.Instance.IsVisible(_metagame))
			{
				if (_hospitalRecord.IsPlayable() || _levelConfig.Instance.IsPlayable(_metagame))
				{
					if (flag)
					{
						_meshIcon.material = (_cursorOver ? _materialHighlightedRemix : _materialDefaultRemix);
					}
					else
					{
						_meshIcon.material = (_cursorOver ? _materialHighlighted : _materialDefault);
					}
					_unseenNotificationsIcon.UnseenNotifications = _metagame.OnlineChallengeViewRecord.GetNumUnseenEventsForOnlineChallengeInLevel(LevelConfig);
					return true;
				}
				if (flag)
				{
					_meshIcon.material = (_cursorOver ? _materialLockedHighlightedRemix : _materialLockedRemix);
				}
				else
				{
					_meshIcon.material = (_cursorOver ? _materialLockedHighlighted : _materialLocked);
				}
				return false;
			}
			return true;
		}

		public override void Refresh(bool refreshVisuals = true)
		{
			if (_metagame == null || _metagameMap?.Metagame == null)
			{
				return;
			}
			_isDlcUnlocked = DLCUtils.IsDLCInstalled(LevelConfig?.GetRequiredDlcPack());
			if (!_isDlcUnlocked && !PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.DLCPurchase))
			{
				GameObjectUtils.SetActive(_meshIcon.gameObject, isActive: false);
				GameObjectUtils.SetActive(_unseenNotificationsIcon.gameObject, isActive: false);
				return;
			}
			if (refreshVisuals)
			{
				RefreshVisual();
			}
			if (!_levelConfig.Instance.IsVisible(_metagame) && _hospitalRecord != null && !_hospitalRecord.IsVisible())
			{
				GameObjectUtils.SetActive(_meshIcon.gameObject, isActive: false);
				GameObjectUtils.SetActive(_unseenNotificationsIcon.gameObject, isActive: false);
				return;
			}
			GameObjectUtils.SetActive(_meshIcon.gameObject, isActive: true);
			if (_hospitalRecord != null)
			{
				int num = _hospitalRecord.TotalStars();
				for (int i = 0; i < num; i++)
				{
					GameObjectUtils.SetActive(_stars[i], isActive: true);
				}
				for (int j = num; j < 3; j++)
				{
					GameObjectUtils.SetActive(_stars[j], isActive: false);
				}
				if (_remixBadgeIcon != null && _remixLevel != null && _remixLevel.IsVisible(_metagame))
				{
					MetagameHospitalRecord hospitalRecord = _metagame.GetHospitalRecord(_remixLevel);
					if (hospitalRecord != null && hospitalRecord.HasRemixBadgePreviouslyBeenAwarded())
					{
						GameObjectUtils.SetActive(_remixBadgeIcon.gameObject, isActive: true);
					}
					else
					{
						GameObjectUtils.SetActive(_remixBadgeIcon.gameObject, isActive: false);
					}
				}
				else if (_remixBadgeIcon != null)
				{
					GameObjectUtils.SetActive(_remixBadgeIcon.gameObject, isActive: false);
				}
			}
			else
			{
				GameObject[] stars = _stars;
				for (int k = 0; k < stars.Length; k++)
				{
					GameObjectUtils.SetActive(stars[k], isActive: false);
				}
				GameObjectUtils.SetActive(_remixBadgeIcon.gameObject, isActive: false);
			}
			if (!RefreshMaterial())
			{
				GameObjectUtils.SetActive(_unseenNotificationsIcon.gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_inProgressIcon, IsPlayingThisLevel());
			GameObjectUtils.SetActive(_hasSaveIcon, SaveIsPresentForThisLevel());
		}

		public override bool IsPinUnlocked()
		{
			if (!_levelConfig.Instance.IsVisible(_metagame))
			{
				if (_hospitalRecord != null)
				{
					return _hospitalRecord.IsVisible();
				}
				return false;
			}
			return true;
		}

		public override void OnDebugClick()
		{
			base.OnDebugClick();
			for (int i = 0; i < _stars.Length; i++)
			{
				if (!_hospitalRecord.HasStarBeenAwarded(i))
				{
					_metagame.AwardStar((MetagameHospitalRecord.StarIndex)i, LevelConfig, debug: true);
					break;
				}
			}
		}

		private void RefreshVisual()
		{
			if (_metagame == null)
			{
				return;
			}
			if (_metagameHospitalVisual != null)
			{
				_metagameHospitalVisual.SetIsUnlocked(_hospitalRecord != null && (_hospitalRecord.IsPlayable() || _levelConfig.Instance.IsPlayable(_metagame)));
			}
			if (IsPlayingThisLevel())
			{
				if (_activeHospitalEffect == null)
				{
					_activeHospitalEffect = UnityEngine.Object.Instantiate(_activeHospitalEffectPrefab, base.transform.position, Quaternion.identity, _metagameMap.RootTransform);
				}
			}
			else
			{
				GameObjectUtils.SafeDestroy(ref _activeHospitalEffect);
			}
		}

		private void OnMetadataReceived()
		{
			Refresh(refreshVisuals: false);
		}

		private LevelConfig GetRemixLevel(LevelConfig levelConfig)
		{
			if (levelConfig.RemixLevelConfig.NotNull())
			{
				LevelConfig instance = levelConfig.RemixLevelConfig.Instance;
				MetagameHospitalRecord hospitalRecord = _metagameMap.Metagame.GetHospitalRecord(instance);
				if (instance.IsVisible(_metagameMap.Metagame) || (hospitalRecord != null && hospitalRecord.IsVisible()))
				{
					return instance;
				}
			}
			return null;
		}
	}
}
