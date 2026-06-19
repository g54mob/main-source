using System;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class PlayerAvatar : MonoBehaviour
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private GameObject _isPlaying;

		[SerializeField]
		private UnseenNotificationsIcon _unseenNotificationsIcon;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		private LevelConfig _levelConfig;

		private OnlineMetadataManager _onlineMetadataManager;

		private CareerStatsManager _careerStatsManager;

		private IResearchNetworkState _researchNetworkState;

		private CollaborativeProjectData _projectData;

		private OnlinePlayerID _playerID;

		private Sprite _overrideSprite;

		public Image Image => _image;

		public OnlinePlayerID PlayerID
		{
			get
			{
				return _playerID;
			}
			set
			{
				if (_playerID != value)
				{
					_playerID = value;
					Refresh();
				}
			}
		}

		public Sprite OverrideSprite
		{
			get
			{
				return _overrideSprite;
			}
			set
			{
				_overrideSprite = value;
				Refresh();
			}
		}

		public int NumUnseenNotifications
		{
			set
			{
				if (_unseenNotificationsIcon != null)
				{
					GameObjectUtils.SetActive(_unseenNotificationsIcon.gameObject, isActive: true);
					_unseenNotificationsIcon.UnseenNotifications = value;
				}
			}
		}

		private void OnEnable()
		{
			Refresh();
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(TooltipUpdate);
			}
			if (OnlineManager.IsInitialized())
			{
				OnlineManager.OnPersonaChanged = (Action<OnlinePlayerID>)Delegate.Combine(OnlineManager.OnPersonaChanged, new Action<OnlinePlayerID>(OnPersonaChanged));
			}
		}

		private void OnDisable()
		{
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(null);
			}
			if (_unseenNotificationsIcon != null)
			{
				GameObjectUtils.SetActive(_unseenNotificationsIcon.gameObject, isActive: false);
			}
			if (OnlineManager.IsInitialized())
			{
				OnlineManager.OnPersonaChanged = (Action<OnlinePlayerID>)Delegate.Remove(OnlineManager.OnPersonaChanged, new Action<OnlinePlayerID>(OnPersonaChanged));
			}
		}

		private void OnDestroy()
		{
		}

		public void Refresh()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn() || _image == null)
			{
				return;
			}
			if (_overrideSprite != null)
			{
				_image.overrideSprite = _overrideSprite;
				_image.color = Color.white;
				_image.preserveAspect = true;
				if (_isPlaying != null)
				{
					GameObjectUtils.SetActive(_isPlaying, isActive: false);
				}
				return;
			}
			if (_isPlaying != null)
			{
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(_playerID);
				if (playerInfo == null)
				{
					_image.overrideSprite = OnlineManager.DefaultAvatarSprite;
					_image.color = Color.white;
					return;
				}
				GameObjectUtils.SetActive(_isPlaying, playerInfo?.IsPlayingGame() ?? false);
			}
			SetAvatarSprite();
		}

		public void SetupForChallengeTooltip(LevelConfig levelConfig, OnlineMetadataManager onlineMetadataManager, CareerStatsManager careerStatsManager)
		{
			_levelConfig = levelConfig;
			_onlineMetadataManager = onlineMetadataManager;
			_careerStatsManager = careerStatsManager;
		}

		public void SetupForCollaboratorTooltip(IResearchNetworkState networkState, CollaborativeProjectData projectData)
		{
			_researchNetworkState = networkState;
			_projectData = projectData;
		}

		private void TooltipUpdate(Tooltip tooltip)
		{
			TooltipPlayerAvatar tooltipPlayerAvatar = tooltip as TooltipPlayerAvatar;
			TooltipCollaborator tooltipCollaborator = tooltip as TooltipCollaborator;
			if (tooltipPlayerAvatar != null && _playerID != OnlinePlayerID.Nil)
			{
				tooltipPlayerAvatar.Setup(_playerID, _levelConfig, _onlineMetadataManager, _careerStatsManager, showChallenge: true, showLevelInfo: true);
				return;
			}
			if (tooltipCollaborator != null && _researchNetworkState != null && _playerID != OnlinePlayerID.Nil)
			{
				tooltipCollaborator.Setup(_playerID, _researchNetworkState, _playerID == OnlineManager.GetLocalPlayerID(), _projectData != null && _projectData.IsDeprecated);
				return;
			}
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(_playerID);
			tooltip.Text = ((_playerID == OnlinePlayerID.Nil || playerInfo == null) ? string.Empty : playerInfo.DisplayName);
		}

		private void SetAvatarSprite()
		{
			if (_overrideSprite != null)
			{
				_image.overrideSprite = _overrideSprite;
				_image.color = ((_overrideSprite != null) ? Color.white : Color.black);
			}
			else
			{
				Sprite avatar = OnlineManager.GetAvatar(_playerID);
				_image.overrideSprite = avatar;
				_image.color = ((avatar != null) ? Color.white : Color.black);
			}
			_image.preserveAspect = true;
		}

		private void OnPersonaChanged(OnlinePlayerID onlinePlayerID)
		{
			if (_playerID == onlinePlayerID)
			{
				Refresh();
			}
		}
	}
}
