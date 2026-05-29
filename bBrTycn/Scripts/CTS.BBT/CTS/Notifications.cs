using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class Notifications : CTSSingleton<Notifications>
	{
		[SerializeField]
		private NotificationObject _notificationPrefab;

		[SerializeField]
		[Inject(false)]
		private Transform _notificationContainer;

		[SerializeField]
		private AudioAsset _defaultAudio;

		private Dictionary<NotificationData, NotificationObject> _nextNotifications = new Dictionary<NotificationData, NotificationObject>();

		private List<NotificationObject> _notifications = new List<NotificationObject>();

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public bool HasNotification(NotificationData data)
		{
			for (int num = _notifications.Count - 1; num >= 0; num--)
			{
				NotificationObject notificationObject = _notifications[num];
				if (!notificationObject)
				{
					_notifications.RemoveAt(num);
				}
				else if (notificationObject.Data == data)
				{
					return true;
				}
			}
			return false;
		}

		public void RemoveAll(NotificationData data)
		{
			for (int num = _notifications.Count - 1; num >= 0; num--)
			{
				NotificationObject notificationObject = _notifications[num];
				if (!notificationObject)
				{
					_notifications.RemoveAt(num);
				}
				else if (notificationObject.Data == data)
				{
					Object.Destroy(notificationObject.gameObject);
					_notifications.RemoveAt(num);
				}
			}
		}

		public void ShowNotification(NotificationData data, bool removable = true)
		{
			if (_nextNotifications.TryGetValue(data, out var value) && value != null && Time.time < value.NextAvailable)
			{
				return;
			}
			NotificationObject notificationObject = CTSFactory.Instantiate(data.PrefabOverride ?? _notificationPrefab, _notificationContainer, instantiateInWorldSpace: false, false);
			notificationObject.Setup(data, removable);
			_notifications.Add(notificationObject);
			notificationObject.gameObject.SetActive(value: true);
			if (data.NeedSoundToPlay)
			{
				if ((object)data.AudioOverride != null)
				{
					MonoSingleton<SoundManager>.Instance.PlayAudioAsset(data.AudioOverride);
				}
				else
				{
					MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_defaultAudio);
				}
			}
			_nextNotifications[data] = notificationObject;
		}
	}
}
