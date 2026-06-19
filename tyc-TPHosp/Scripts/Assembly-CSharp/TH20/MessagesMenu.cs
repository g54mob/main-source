using System;
using FullInspector;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MessagesMenu : MenuBase
	{
		[SerializeField]
		private bool _display;

		[SerializeField]
		private Sprite _selectedBackgroundSprite;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[InspectorMargin(8)]
		[SerializeField]
		private NotificationList _notificationList;

		[InspectorMargin(8)]
		[SerializeField]
		private DynamicButton _notificationsToggleButton;

		[InspectorMargin(8)]
		[SerializeField]
		private Image _notificationsBackgroundImage;

		[InspectorMargin(8)]
		[SerializeField]
		private RectTransform _notificationsCountTransform;

		[InspectorMargin(8)]
		[SerializeField]
		private TMP_Text _notificationsCountText;

		[InspectorMargin(8)]
		[SerializeField]
		private GameObject _tutorialGameObject;

		[InspectorMargin(8)]
		[SerializeField]
		private DynamicButton _inboxButton;

		private Level _level;

		private InputManager _inputManager;

		private Notifications _notifications;

		public void Setup(Level level, App app, Notifications notifications, ObjectiveEvents objectiveEvents, InputManager inputManager)
		{
			_level = level;
			_inputManager = inputManager;
			_notifications = notifications;
			if (_notificationsToggleButton != null)
			{
				_notificationsToggleButton.onPrimaryDown.AddListener(OnNotificationsToggleButtonClick);
			}
			if (_notificationList != null)
			{
				_notificationList.Setup(notifications);
			}
			if (_inboxButton != null)
			{
				_inboxButton.onPrimaryDown.AddListener(OnInboxButtonClick);
			}
			Notifications notifications2 = _notifications;
			notifications2.OnNotificationSent = (Action<NotificationMessage>)Delegate.Combine(notifications2.OnNotificationSent, new Action<NotificationMessage>(OnNotificationSent));
			Notifications notifications3 = _notifications;
			notifications3.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Combine(notifications3.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
			_inputManager.AddGraphicRayCaster(_graphicRaycaster);
			Hide();
			Show();
			RefreshNotificationCount();
		}

		public void ToggleMode()
		{
			if (_display)
			{
				Hide();
				_display = false;
			}
			else
			{
				Show();
				_display = true;
			}
			RefreshNotificationCount();
		}

		private void Hide()
		{
			if (_notificationList != null)
			{
				_notificationList.gameObject.SetActive(value: false);
			}
			if (_notificationsBackgroundImage != null)
			{
				_notificationsBackgroundImage.overrideSprite = null;
			}
		}

		private void Show()
		{
			if (_notificationList != null)
			{
				_notificationList.gameObject.SetActive(value: true);
			}
			if (_notificationsBackgroundImage != null)
			{
				_notificationsBackgroundImage.overrideSprite = _selectedBackgroundSprite;
			}
		}

		private void RefreshNotificationCount()
		{
			bool num = _notifications.NumOfMessages > 0;
			bool display = _display;
			if (num && !display)
			{
				_notificationsCountTransform.gameObject.SetActive(value: true);
				_notificationsCountText.text = Mathf.Clamp(_notifications.NumOfMessages, 1, 9).ToString("0");
			}
			else
			{
				_notificationsCountTransform.gameObject.SetActive(value: false);
			}
		}

		public int GetNotificationCount()
		{
			if (_notifications == null)
			{
				return 0;
			}
			return _notifications.NumOfMessages;
		}

		private void OnInboxButtonClick()
		{
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(InboxMenu m)
			{
				m.Setup(InboxMenu.Mode.Archive);
			});
		}

		private void OnNotificationsToggleButtonClick()
		{
			ToggleMode();
		}

		private void OnNotificationSent(NotificationMessage notificationMessage)
		{
			RefreshNotificationCount();
		}

		private void OnNotificationRemoved(NotificationMessage notificationMessage)
		{
			RefreshNotificationCount();
		}

		public void ShowTutorialHighlight(bool show)
		{
			GameObjectUtils.SetActive(_tutorialGameObject, show);
		}

		public void OnDestroy()
		{
			if (_inputManager != null)
			{
				_inputManager.RemoveGraphicRayCaster(_graphicRaycaster);
			}
			if (_notifications != null)
			{
				Notifications notifications = _notifications;
				notifications.OnNotificationSent = (Action<NotificationMessage>)Delegate.Remove(notifications.OnNotificationSent, new Action<NotificationMessage>(OnNotificationSent));
				Notifications notifications2 = _notifications;
				notifications2.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Remove(notifications2.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
			}
			if (_notificationList != null)
			{
				_notificationList.Destroy();
			}
		}
	}
}
