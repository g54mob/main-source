using System;
using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using Motorways.Processes;
using UnityEngine;

namespace Motorways.Views
{
	public class NotificationView : IView, IReusable
	{
		private class RecentError
		{
			public TileEditResultCode code;

			public float age;

			public RecentError(TileEditResultCode resultCode)
			{
				code = resultCode;
				age = 0f;
			}
		}

		public enum AlertIconType
		{
			Cross = 0,
			Exclaimation = 1
		}

		private const float MessageViewPosition = 0.7f;

		private const float MinMessageDuration = 1.5f;

		private const float MaxMessageDuration = 4f;

		private const float MessageCooldownDuration = 1f;

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("NotificationView");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private City _city;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private InputState _inputState;

		[Dependency]
		private GameUIScreen _gameUI;

		[Dependency]
		private TutorialProgressionProcess _tutorialProcess;

		[Dependency]
		private VisualConstantsData _visualConstants;

		private AnchoredMessageView _notification;

		private MotorwaysStringKey _notificationMessage;

		private float _notificationTime;

		private float _notificationCooldown;

		private float _nextNotificationDelay;

		private float _notificationDelay;

		private IndicatorAnimationView _alertIcon;

		private TileEditResultCode _alertReason;

		private bool _notificationHideScheduled;

		private MotorwaysStringKey _pendingNotificationMessage;

		private Func<bool> _hideCondition;

		private bool _isControllerNotificationUp;

		private readonly List<RecentError> _recentErrors = new List<RecentError>();

		public bool NotificationsEnabled { get; set; } = true;

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_tutorialProcess != null && _tutorialProcess.HasVisibleMessage)
			{
				_pendingNotificationMessage = null;
				DismissNotification();
			}
			if (_notification != null)
			{
				if (_hideCondition != null)
				{
					if (_hideCondition())
					{
						DismissNotification();
					}
				}
				else
				{
					_notificationTime -= timeInterval.Delta;
					if (_notificationTime <= 0f || ((_pendingNotificationMessage != null || _notificationHideScheduled) && 4f - _notificationTime > 1.5f))
					{
						DismissNotification();
					}
				}
			}
			else
			{
				_notificationCooldown = Mathf.Max(0f, _notificationCooldown - timeInterval.Delta);
				if (_notificationCooldown <= 0f)
				{
					_notificationDelay = Mathf.Max(0f, _notificationDelay - timeInterval.Delta);
				}
				if (_notificationCooldown <= 0f && _notificationDelay <= 0f && _pendingNotificationMessage != null)
				{
					ShowNotification(_pendingNotificationMessage);
					_pendingNotificationMessage = null;
					_recentErrors.Clear();
				}
			}
			for (int i = 0; i < _recentErrors.Count; i++)
			{
				if (_recentErrors[i].age > _visualConstants.RepeatRecentErrorTimeWindow)
				{
					_recentErrors.RemoveAt(i);
					i--;
				}
				else
				{
					_recentErrors[i].age += timeInterval.Delta;
				}
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
		}

		public bool AddNotification(TileEditResultCode tileEditErrorCode, Vector2Int position)
		{
			switch (tileEditErrorCode)
			{
			case TileEditResultCode.CannotCreateBridge:
				_gameUI.UpgradeBar.BounceUpgrade(UpgradeType.Bridge);
				break;
			case TileEditResultCode.CannotCreateTunnel:
				_gameUI.UpgradeBar.BounceUpgrade(UpgradeType.Tunnel);
				break;
			case TileEditResultCode.NotEnoughConcrete:
				_gameUI.UpgradeBar.BounceUpgrade(UpgradeType.Concrete);
				break;
			}
			if (!NotificationsEnabled)
			{
				return false;
			}
			bool flag = false;
			AlertIconType type = AlertIconType.Cross;
			StringId stringId = StringId.None;
			switch (tileEditErrorCode)
			{
			case TileEditResultCode.CannotConnectToCarpark:
				if (_city.Rules.ShowCannotConnectToCarparkErrorNotification())
				{
					stringId = StringId.Error_CannotConnectToCarpark;
				}
				flag = true;
				break;
			case TileEditResultCode.CannotConnectHouseToBridge:
				stringId = StringId.Error_CannotConnectHouseToBridge;
				flag = true;
				break;
			case TileEditResultCode.CannotConnectHouseToTunnel:
				stringId = StringId.Error_CannotConnectHouseToTunnel;
				flag = true;
				break;
			case TileEditResultCode.NotEnoughConcrete:
				if (_city.Rules.ShowNoConcreteErrorNotification())
				{
					stringId = _city.Rules.GetNoConcreteErrorMessage(_inputState.CurrentDeviceInputType);
					type = AlertIconType.Exclaimation;
					flag = true;
				}
				break;
			case TileEditResultCode.NotEnoughConcreteForMotorway:
				stringId = StringId.Error_NotEnoughConcreteMotorway;
				break;
			case TileEditResultCode.MotorwayBlockedByMountain:
				stringId = StringId.Error_MotorwayCollidesWithMountain;
				break;
			case TileEditResultCode.CannotCreateBridge:
			case TileEditResultCode.CannotCreateTunnel:
				flag = true;
				type = AlertIconType.Exclaimation;
				break;
			case TileEditResultCode.NoDeletableRoads:
				flag = true;
				stringId = StringId.Error_NoDeletableRoads;
				break;
			case TileEditResultCode.NoDeletableUpgrade:
				flag = true;
				stringId = StringId.Error_NoDeletableUpgrades;
				break;
			case TileEditResultCode.CannotConnectHouseToRail:
				flag = true;
				stringId = StringId.Error_CannotConnectHouseToRail;
				break;
			}
			_recentErrors.Add(new RecentError(tileEditErrorCode));
			if (flag)
			{
				ShowIconNotification(type, position, tileEditErrorCode);
			}
			if (stringId != StringId.None)
			{
				return AddNotification(stringId, GetDelayForError(flag, tileEditErrorCode));
			}
			return false;
		}

		private float GetDelayForError(bool isSendingAlert, TileEditResultCode reason)
		{
			float result = (isSendingAlert ? _visualConstants.TimeAfterIconAppearsWhenNotificationAppears : 0f);
			int num = 0;
			foreach (RecentError recentError in _recentErrors)
			{
				if (recentError.code == reason)
				{
					num++;
				}
			}
			if (num >= _visualConstants.RepeatRecentErrorCount)
			{
				result = 0f;
			}
			return result;
		}

		public bool ShowIconNotification(AlertIconType type, Vector2Int position, TileEditResultCode reason)
		{
			if (reason == _alertReason)
			{
				return false;
			}
			if (_alertIcon != null)
			{
				HideAlertIcon();
			}
			IndicatorAnimationView indicatorAnimationView = _scope.Get<IndicatorAnimationView>();
			indicatorAnimationView.Initialize(IndicatorAnimationView.AnimationType.Alert, position.ToVector3() * 2f);
			indicatorAnimationView.SetAlertType(type);
			_viewClient.AddView(indicatorAnimationView);
			_alertIcon = indicatorAnimationView;
			_alertReason = reason;
			return true;
		}

		public bool AddNotification(MotorwaysStringKey newNotificationMessage, float delay = 0f, Func<bool> hideCondition = null)
		{
			if (hideCondition != null)
			{
				if (hideCondition())
				{
					return false;
				}
				_hideCondition = hideCondition;
			}
			if (_notification != null && _notificationMessage.Equals(newNotificationMessage))
			{
				_notificationTime = 4f;
				_pendingNotificationMessage = null;
				_notificationHideScheduled = false;
			}
			else
			{
				if (_notification == null && _pendingNotificationMessage != newNotificationMessage)
				{
					_notificationDelay = delay;
				}
				else
				{
					_nextNotificationDelay = delay;
				}
				_pendingNotificationMessage = newNotificationMessage;
			}
			return true;
		}

		public void HideAlertIcon()
		{
			_alertReason = TileEditResultCode.Success;
			if (_alertIcon != null)
			{
				_alertIcon.OnAnimationRelease();
				_alertIcon = null;
			}
		}

		public void HideNotification()
		{
			_notificationHideScheduled = true;
			_pendingNotificationMessage = null;
			_notificationTime = 1.5f;
		}

		public void CancelNotification()
		{
			_notificationDelay = 0f;
			_nextNotificationDelay = 0f;
			_pendingNotificationMessage = null;
		}

		public void Reset()
		{
			_notification = null;
			_notificationMessage = null;
			_notificationTime = 0f;
			_notificationCooldown = 0f;
			_nextNotificationDelay = 0f;
			_notificationDelay = 0f;
			_notificationHideScheduled = false;
			_pendingNotificationMessage = null;
			_isControllerNotificationUp = false;
			NotificationsEnabled = true;
			_recentErrors.Clear();
		}

		private void ShowNotification(MotorwaysStringKey notificationMessage)
		{
			_notification = _scope.Get<AnchoredMessageView>();
			_notification.InitializeWithScreenAnchor(StandaloneLocString.CreateString(_scope, notificationMessage), new Vector2(0f, 0.7f));
			_viewClient.AddView(_notification);
			_notificationTime = (_isControllerNotificationUp ? float.MaxValue : 4f);
			_notificationHideScheduled = false;
			_notificationMessage = notificationMessage;
		}

		private void DismissNotification()
		{
			if (_notification != null)
			{
				_notification.OnAnimationRelease();
				_notification = null;
				_notificationCooldown = 1f;
			}
			_notificationDelay = _nextNotificationDelay;
			_isControllerNotificationUp = false;
			_hideCondition = null;
		}

		public void KillNotification()
		{
			if (_notification != null)
			{
				_notification.Kill();
				_notification = null;
				_notificationCooldown = 1f;
			}
			_notificationDelay = _nextNotificationDelay;
			_isControllerNotificationUp = false;
			_hideCondition = null;
		}
	}
}
