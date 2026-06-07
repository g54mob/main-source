using System;
using System.Collections.Generic;
using Data.Notifications;
using Data.Variables;
using Events;
using Events.UI.Notifications;
using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	public class NotificationPopupsUI : MonoBehaviour
	{
		[SerializeField]
		private BaseEvent _startLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _showHUDUIEvent;

		[SerializeField]
		private BoolVariableSO _hudUIIsHidden;

		[SerializeField]
		private NotificationEvent _notificationEvent;

		[Header("Popups")]
		[SerializeField]
		private NotificationPopup _moduleNotificationPopup;

		[SerializeField]
		private NotificationPopup _rankNotificationPopup;

		[SerializeField]
		private NotificationPopup _genericNotificationPopup;

		private readonly Queue<AbstractNotificationData> _queue = new Queue<AbstractNotificationData>();

		private bool _isPopupOpen;

		private void Awake()
		{
			_notificationEvent.Register(HandleShowNotificationPopupEvent);
			_startLoadingSaveEvent.Register(HandleStartLoadingSave);
			_showHUDUIEvent.Register(OnShowHUDUI);
			NotificationPopup moduleNotificationPopup = _moduleNotificationPopup;
			moduleNotificationPopup.OnClose = (Action)Delegate.Combine(moduleNotificationPopup.OnClose, new Action(OnPopupClosed));
			NotificationPopup rankNotificationPopup = _rankNotificationPopup;
			rankNotificationPopup.OnClose = (Action)Delegate.Combine(rankNotificationPopup.OnClose, new Action(OnPopupClosed));
			NotificationPopup genericNotificationPopup = _genericNotificationPopup;
			genericNotificationPopup.OnClose = (Action)Delegate.Combine(genericNotificationPopup.OnClose, new Action(OnPopupClosed));
		}

		private void OnDestroy()
		{
			_notificationEvent.UnRegister(HandleShowNotificationPopupEvent);
			_startLoadingSaveEvent.UnRegister(HandleStartLoadingSave);
			_showHUDUIEvent.UnRegister(OnShowHUDUI);
			NotificationPopup moduleNotificationPopup = _moduleNotificationPopup;
			moduleNotificationPopup.OnClose = (Action)Delegate.Remove(moduleNotificationPopup.OnClose, new Action(OnPopupClosed));
			NotificationPopup rankNotificationPopup = _rankNotificationPopup;
			rankNotificationPopup.OnClose = (Action)Delegate.Remove(rankNotificationPopup.OnClose, new Action(OnPopupClosed));
			NotificationPopup genericNotificationPopup = _genericNotificationPopup;
			genericNotificationPopup.OnClose = (Action)Delegate.Remove(genericNotificationPopup.OnClose, new Action(OnPopupClosed));
		}

		private void HandleStartLoadingSave()
		{
			_queue.Clear();
		}

		private void HandleShowNotificationPopupEvent(AbstractNotificationData data)
		{
			AddToQueue(data);
		}

		private void AddToQueue(AbstractNotificationData data)
		{
			_queue.Enqueue(data);
			TryShowNextPopup();
		}

		private void TryShowNextPopup()
		{
			if (_queue.Count != 0 && !_hudUIIsHidden.Value && !_isPopupOpen)
			{
				AbstractNotificationData abstractNotificationData = _queue.Dequeue();
				_isPopupOpen = true;
				if (abstractNotificationData is ModuleNotificationData)
				{
					_moduleNotificationPopup.Build(abstractNotificationData);
				}
				else if (abstractNotificationData is RankNotificationData)
				{
					_rankNotificationPopup.Build(abstractNotificationData);
				}
				else if (abstractNotificationData is GenericNotificationData)
				{
					_genericNotificationPopup.Build(abstractNotificationData);
				}
			}
		}

		private void OnPopupClosed()
		{
			_isPopupOpen = false;
			TryShowNextPopup();
		}

		private void OnShowHUDUI()
		{
			if (!_isPopupOpen)
			{
				TryShowNextPopup();
			}
		}
	}
}
