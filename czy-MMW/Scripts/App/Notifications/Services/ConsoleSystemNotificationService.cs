using System;
using System.Collections.Generic;
using System.Linq;
using Factory;
using Notifications.Triggers;

namespace Notifications.Services
{
	public class ConsoleSystemNotificationService : ISystemNotificationService
	{
		public const string DebugSystemNotificationsEditorPrefKey = "DebugSystemNotificationsEditorPrefKey";

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ConsoleSystemNotificationService");

		private readonly Dictionary<string, SystemNotification> _scheduledNotifications = new Dictionary<string, SystemNotification>();

		private readonly Dictionary<string, SystemNotification> _deliveredNotifications = new Dictionary<string, SystemNotification>();

		private AuthorizationStatus _authorizationStatus;

		[Dependency]
		private TickRegistry _tickRegistry;

		public int ApplicationBadge { get; set; }

		public List<SystemNotification> ScheduledNotifications => _deliveredNotifications.Values.ToList();

		public List<SystemNotification> DeliveredNotifications => _scheduledNotifications.Values.ToList();

		public bool IsAvailable => true;

		public AuthorizationStatus AuthorizationStatus
		{
			get
			{
				return _authorizationStatus;
			}
			private set
			{
				_authorizationStatus = value;
			}
		}

		public bool RequiresOptionsPanel => false;

		public event NotificationReceived OnNotificationReceived;

		public void RemoveAllDeliveredNotifications()
		{
			_deliveredNotifications.Clear();
		}

		public void RequestAuthorization(OnAuthorizationRequestComplete authorizationRequestComplete)
		{
			bool flag = true;
			AuthorizationStatus = ((!flag) ? AuthorizationStatus.Denied : AuthorizationStatus.Authorized);
			authorizationRequestComplete?.Invoke(AuthorizationStatus == AuthorizationStatus.Authorized);
		}

		public void Setup()
		{
			if (AuthorizationStatus == AuthorizationStatus.Authorized)
			{
				_tickRegistry.AppTicking += Tick;
			}
		}

		public void ScheduleNotification(string identifier, SystemNotificationContent content, SystemNotificationTrigger trigger)
		{
			_scheduledNotifications.Add(identifier, new SystemNotification(identifier, content, trigger));
			if (trigger is CalendarNotificationTrigger calendarNotificationTrigger)
			{
				Log.Info($"ScheduleNotification({identifier}, {content.Title}) for {calendarNotificationTrigger.Hour} {calendarNotificationTrigger.Day}/{calendarNotificationTrigger.Month}/{calendarNotificationTrigger.Year}");
			}
		}

		public void RemoveScheduledNotification(string identifier)
		{
			_scheduledNotifications.Remove(identifier);
			Log.Info("RemoveScheduledNotification(" + identifier + ")");
		}

		public void RemoveAllScheduledNotifications()
		{
			_scheduledNotifications.Clear();
		}

		private void Tick(float deltaTime)
		{
			if (AuthorizationStatus != AuthorizationStatus.Authorized)
			{
				_tickRegistry.AppTicking -= Tick;
				return;
			}
			DateTime utcNow = GameDateTime.UtcNow;
			List<KeyValuePair<string, SystemNotification>> list = new List<KeyValuePair<string, SystemNotification>>();
			foreach (KeyValuePair<string, SystemNotification> scheduledNotification in _scheduledNotifications)
			{
				if (scheduledNotification.Value.Trigger is CalendarNotificationTrigger calendarTrigger && !_deliveredNotifications.ContainsKey(scheduledNotification.Key))
				{
					DateTime dateTime = DeliveryTime(calendarTrigger);
					if (utcNow >= dateTime && utcNow < dateTime + TimeSpan.FromSeconds(30.0))
					{
						list.Add(scheduledNotification);
					}
				}
			}
			foreach (KeyValuePair<string, SystemNotification> item in list)
			{
				Log.Info("[Notification] " + item.Key);
				this.OnNotificationReceived?.Invoke(item.Key, item.Value.Content);
				if (item.Value.Content.Badge >= 0)
				{
					ApplicationBadge = item.Value.Content.Badge;
				}
				RemoveScheduledNotification(item.Key);
				_deliveredNotifications.Add(item.Key, item.Value);
			}
		}

		private DateTime DeliveryTime(CalendarNotificationTrigger calendarTrigger)
		{
			DateTime utcNow = GameDateTime.UtcNow;
			return new DateTime(calendarTrigger.Year ?? utcNow.Year, calendarTrigger.Month ?? utcNow.Month, calendarTrigger.Day ?? utcNow.Day, calendarTrigger.Hour ?? utcNow.Hour, calendarTrigger.Minute ?? utcNow.Minute, calendarTrigger.Second ?? utcNow.Second, DateTimeKind.Local);
		}
	}
}
