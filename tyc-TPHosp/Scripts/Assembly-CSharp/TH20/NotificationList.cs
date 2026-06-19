using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class NotificationList : MonoBehaviour
	{
		[SerializeField]
		private int _maxMessagesToDisplay = 5;

		[SerializeField]
		private GameObject _notificationListItem;

		private bool _isSetup;

		private Notifications _notifications;

		private List<NotificationMessage> _cachedNotificationMessages = new List<NotificationMessage>();

		private List<NotificationMenuListItem> _cachedNotificationMenuListItem = new List<NotificationMenuListItem>();

		public void Setup(Notifications notifications)
		{
			_notifications = notifications;
			Notifications notifications2 = _notifications;
			notifications2.OnNotificationSent = (Action<NotificationMessage>)Delegate.Combine(notifications2.OnNotificationSent, new Action<NotificationMessage>(OnNotificationSent));
			Notifications notifications3 = _notifications;
			notifications3.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Combine(notifications3.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
			_isSetup = true;
		}

		public void OnEnable()
		{
			if (_isSetup)
			{
				CheckForNotificationsToPush();
			}
		}

		public void Destroy()
		{
			if (_notifications != null)
			{
				Notifications notifications = _notifications;
				notifications.OnNotificationSent = (Action<NotificationMessage>)Delegate.Remove(notifications.OnNotificationSent, new Action<NotificationMessage>(OnNotificationSent));
				Notifications notifications2 = _notifications;
				notifications2.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Remove(notifications2.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
			}
		}

		private void CheckForNotificationsToPush()
		{
			_cachedNotificationMenuListItem.Clear();
			GetComponentsInChildren(_cachedNotificationMenuListItem);
			_cachedNotificationMessages.Clear();
			_notifications.GetNotificationMessages(_cachedNotificationMessages);
			int num = _cachedNotificationMenuListItem.Count;
			foreach (NotificationMessage message in _cachedNotificationMessages)
			{
				if (num >= _maxMessagesToDisplay)
				{
					break;
				}
				if (_cachedNotificationMenuListItem.TrueForAll((NotificationMenuListItem item) => !item.ContainsMessage(message)) && PushNotificationIcon(message))
				{
					num++;
				}
			}
		}

		private bool PushNotificationIcon(NotificationMessage message)
		{
			_cachedNotificationMenuListItem.Clear();
			GetComponentsInChildren(_cachedNotificationMenuListItem);
			NotificationMenuListItem notificationMenuListItem = null;
			foreach (NotificationMenuListItem item in _cachedNotificationMenuListItem)
			{
				if (item.Icon == message.Definition._icon)
				{
					notificationMenuListItem = item;
				}
			}
			if (notificationMenuListItem != null)
			{
				notificationMenuListItem.AddMessage(message);
				return false;
			}
			UnityEngine.Object.Instantiate(_notificationListItem, base.transform, worldPositionStays: false).GetComponent<NotificationMenuListItem>().Setup(message.Definition._icon, message, _notifications);
			return true;
		}

		private void OnNotificationSent(NotificationMessage message)
		{
			CheckForNotificationsToPush();
		}

		private void OnNotificationRemoved(NotificationMessage message)
		{
			_cachedNotificationMenuListItem.Clear();
			GetComponentsInChildren(_cachedNotificationMenuListItem);
			foreach (NotificationMenuListItem item in _cachedNotificationMenuListItem)
			{
				if (item.RemoveMessage(message) && item.MessagesCount == 0)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			CheckForNotificationsToPush();
		}
	}
}
