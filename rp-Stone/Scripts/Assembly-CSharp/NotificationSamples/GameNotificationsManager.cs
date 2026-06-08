using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace NotificationSamples
{
	public class GameNotificationsManager : MonoBehaviour
	{
		[Flags]
		public enum OperatingMode
		{
			NoQueue = 0,
			Queue = 1,
			ClearOnForegrounding = 2,
			RescheduleAfterClearing = 4,
			QueueAndClear = 3,
			QueueClearAndReschedule = 7
		}

		private const string DefaultFilename = "notifications.bin";

		private static readonly TimeSpan MinimumNotificationTime = new TimeSpan(0, 0, 2);

		[SerializeField]
		[Tooltip("The operating mode for the notifications manager.")]
		private OperatingMode mode = OperatingMode.QueueClearAndReschedule;

		[SerializeField]
		[Tooltip("Check to make the notifications manager automatically set badge numbers so that they increment.\nSchedule notifications with no numbers manually set to make use of this feature.")]
		private bool autoBadging = true;

		private bool inForeground = true;

		public IGameNotificationsPlatform Platform { get; private set; }

		public List<PendingNotification> PendingNotifications { get; private set; }

		public IPendingNotificationsSerializer Serializer { get; set; }

		public OperatingMode Mode => mode;

		public bool AutoBadging => autoBadging;

		public bool Initialized { get; private set; }

		public event Action<PendingNotification> LocalNotificationDelivered;

		public event Action<PendingNotification> LocalNotificationExpired;

		protected virtual void OnDestroy()
		{
			if (Platform != null)
			{
				Platform.NotificationReceived -= OnNotificationReceived;
				if (Platform is IDisposable disposable)
				{
					disposable.Dispose();
				}
				inForeground = false;
			}
		}

		protected virtual void Update()
		{
			if (PendingNotifications == null || !PendingNotifications.Any() || (mode & OperatingMode.Queue) != OperatingMode.Queue)
			{
				return;
			}
			for (int num = PendingNotifications.Count - 1; num >= 0; num--)
			{
				PendingNotification pendingNotification = PendingNotifications[num];
				DateTime? deliveryTime = pendingNotification.Notification.DeliveryTime;
				if (deliveryTime.HasValue && deliveryTime < DateTime.Now)
				{
					PendingNotifications.RemoveAt(num);
					this.LocalNotificationExpired?.Invoke(pendingNotification);
				}
			}
		}

		protected void OnApplicationFocus(bool hasFocus)
		{
			if (Platform == null || !Initialized)
			{
				return;
			}
			inForeground = hasFocus;
			if (hasFocus)
			{
				OnForegrounding();
				return;
			}
			Platform.OnBackground();
			if ((mode & OperatingMode.Queue) == OperatingMode.Queue)
			{
				for (int num = PendingNotifications.Count - 1; num >= 0; num--)
				{
					PendingNotification pendingNotification = PendingNotifications[num];
					if (!pendingNotification.Notification.Scheduled && pendingNotification.Notification.DeliveryTime.HasValue && pendingNotification.Notification.DeliveryTime - DateTime.Now < MinimumNotificationTime)
					{
						PendingNotifications.RemoveAt(num);
					}
				}
				bool flag = PendingNotifications.All((PendingNotification notification) => !notification.Notification.BadgeNumber.HasValue);
				if (flag && AutoBadging)
				{
					PendingNotifications.Sort(delegate(PendingNotification a, PendingNotification b)
					{
						if (!a.Notification.DeliveryTime.HasValue)
						{
							return 1;
						}
						return (!b.Notification.DeliveryTime.HasValue) ? (-1) : a.Notification.DeliveryTime.Value.CompareTo(b.Notification.DeliveryTime.Value);
					});
					int num2 = 1;
					foreach (PendingNotification pendingNotification3 in PendingNotifications)
					{
						if (pendingNotification3.Notification.DeliveryTime.HasValue && !pendingNotification3.Notification.Scheduled)
						{
							pendingNotification3.Notification.BadgeNumber = num2++;
						}
					}
				}
				for (int num3 = PendingNotifications.Count - 1; num3 >= 0; num3--)
				{
					PendingNotification pendingNotification2 = PendingNotifications[num3];
					if (!pendingNotification2.Notification.Scheduled)
					{
						Platform.ScheduleNotification(pendingNotification2.Notification);
					}
				}
				if (flag && AutoBadging)
				{
					foreach (PendingNotification pendingNotification4 in PendingNotifications)
					{
						if (pendingNotification4.Notification.DeliveryTime.HasValue)
						{
							pendingNotification4.Notification.BadgeNumber = null;
						}
					}
				}
			}
			List<PendingNotification> list = new List<PendingNotification>(PendingNotifications.Count);
			foreach (PendingNotification pendingNotification5 in PendingNotifications)
			{
				if ((mode & OperatingMode.ClearOnForegrounding) == OperatingMode.ClearOnForegrounding)
				{
					if ((mode & OperatingMode.RescheduleAfterClearing) == OperatingMode.RescheduleAfterClearing && pendingNotification5.Reschedule && pendingNotification5.Notification.Scheduled && pendingNotification5.Notification.DeliveryTime.HasValue)
					{
						list.Add(pendingNotification5);
					}
				}
				else if (pendingNotification5.Notification.Scheduled)
				{
					list.Add(pendingNotification5);
				}
			}
			Serializer.Serialize(list);
		}

		public IEnumerator Initialize(GameNotificationChannel[] channels)
		{
			if (Initialized)
			{
				throw new InvalidOperationException("NotificationsManager already initialized.");
			}
			Initialized = true;
			if (Platform != null)
			{
				PendingNotifications = new List<PendingNotification>();
				Platform.NotificationReceived += OnNotificationReceived;
				if (Serializer == null)
				{
					Serializer = new DefaultSerializer(Path.Combine(Application.persistentDataPath, "notifications.bin"));
				}
				yield return Platform.RequestNotificationPermission();
				OnForegrounding();
			}
		}

		public IGameNotification CreateNotification()
		{
			if (!Initialized)
			{
				throw new InvalidOperationException("Must call Initialize() first.");
			}
			return Platform?.CreateNotification();
		}

		public PendingNotification ScheduleNotification(IGameNotification notification)
		{
			if (!Initialized)
			{
				throw new InvalidOperationException("Must call Initialize() first.");
			}
			if (notification == null || Platform == null)
			{
				return null;
			}
			if ((mode & OperatingMode.Queue) != OperatingMode.Queue || !notification.DeliveryTime.HasValue)
			{
				Platform.ScheduleNotification(notification);
			}
			else if (!notification.Id.HasValue)
			{
				int value = Math.Abs(DateTime.Now.ToString("yyMMddHHmmssffffff").GetHashCode());
				notification.Id = value;
			}
			PendingNotification pendingNotification = new PendingNotification(notification);
			PendingNotifications.Add(pendingNotification);
			return pendingNotification;
		}

		public void CancelNotification(int notificationId)
		{
			if (!Initialized)
			{
				throw new InvalidOperationException("Must call Initialize() first.");
			}
			if (Platform != null)
			{
				Platform.CancelNotification(notificationId);
				int num = PendingNotifications.FindIndex((PendingNotification scheduledNotification) => scheduledNotification.Notification.Id == notificationId);
				if (num >= 0)
				{
					PendingNotifications.RemoveAt(num);
				}
			}
		}

		public void CancelAllNotifications()
		{
			if (!Initialized)
			{
				throw new InvalidOperationException("Must call Initialize() first.");
			}
			if (Platform != null)
			{
				Platform.CancelAllScheduledNotifications();
				PendingNotifications.Clear();
			}
		}

		public void DismissNotification(int notificationId)
		{
			if (!Initialized)
			{
				throw new InvalidOperationException("Must call Initialize() first.");
			}
			Platform?.DismissNotification(notificationId);
		}

		public void DismissAllNotifications()
		{
			if (!Initialized)
			{
				throw new InvalidOperationException("Must call Initialize() first.");
			}
			Platform?.DismissAllDisplayedNotifications();
		}

		public IGameNotification GetLastNotification()
		{
			if (!Initialized)
			{
				throw new InvalidOperationException("Must call Initialize() first.");
			}
			return Platform?.GetLastNotification();
		}

		private void OnNotificationReceived(IGameNotification deliveredNotification)
		{
			if (inForeground)
			{
				int num = PendingNotifications.FindIndex((PendingNotification scheduledNotification) => scheduledNotification.Notification.Id == deliveredNotification.Id);
				if (num >= 0)
				{
					this.LocalNotificationDelivered?.Invoke(PendingNotifications[num]);
					PendingNotifications.RemoveAt(num);
				}
			}
		}

		private void OnForegrounding()
		{
			PendingNotifications.Clear();
			Platform.OnForeground();
			IList<IGameNotification> list = Serializer?.Deserialize(Platform);
			if ((mode & OperatingMode.ClearOnForegrounding) == OperatingMode.ClearOnForegrounding)
			{
				Platform.CancelAllScheduledNotifications();
				if (list == null || (mode & OperatingMode.RescheduleAfterClearing) != OperatingMode.RescheduleAfterClearing)
				{
					return;
				}
				{
					foreach (IGameNotification item in list)
					{
						if (item.DeliveryTime > DateTime.Now)
						{
							ScheduleNotification(item).Reschedule = true;
						}
					}
					return;
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (IGameNotification item2 in list)
			{
				if (item2.DeliveryTime > DateTime.Now)
				{
					PendingNotifications.Add(new PendingNotification(item2));
				}
			}
		}
	}
}
