using System;
using System.Collections.Generic;
using Factory;
using Notifications;
using Notifications.Triggers;

public class NotificationScheduler
{
	public class DatePeriod
	{
		public DateTime startDate;

		public DateTime? endDate;
	}

	private const int MaxNumberOfDaysToScheduleFor = 30;

	private const int LocalNotificationTimeHour = 9;

	private const int LocalNotificationTimeMinute = 30;

	[Dependency]
	private IScope _scope;

	[Dependency]
	private ISystemNotificationService _systemNotificationService;

	[Dependency]
	private NotificationDescriptorDatabase _notificationDescriptorDatabase;

	[Dependency]
	private INotificationEventSystem _notificationEventSystem;

	[Dependency]
	private INotificationScheduleDebugger _scheduleDebugger;

	[Dependency]
	private IActivePlayer _player;

	private LocaleDatabase.LocaleId _scheduledLocale;

	private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("NotificationScheduler");

	private int _testNotificationIndex;

	public const int TestNotificationSeconds = 15;

	public void OnPlayerChanged(Player oldPlayer, Player newPlayer)
	{
		_scheduledLocale = LocaleDatabase.LocaleId.Unknown;
	}

	public void OnPlayerDataChanged()
	{
		LocaleDatabase.LocaleId localeId = _player.LocaleId;
		if (localeId != _scheduledLocale)
		{
			_scheduledLocale = localeId;
			ScheduleNotifications();
		}
	}

	public void ScheduleTestNotification()
	{
		if (_notificationDescriptorDatabase.gameNotifications.Count > 0)
		{
			NotificationDescriptor notificationDescriptor = _notificationDescriptorDatabase.gameNotifications[_testNotificationIndex];
			SystemNotificationContent content = CreateSystemNotificationContentFromDescriptor(notificationDescriptor);
			int num = GameDateTime.UtcNow.Second + 15;
			if (num >= 60)
			{
				num -= 60;
			}
			CalendarNotificationTrigger trigger = new CalendarNotificationTrigger
			{
				Second = num
			};
			_systemNotificationService.ScheduleNotification($"{notificationDescriptor.Id}_test", content, trigger);
			_testNotificationIndex++;
			if (_testNotificationIndex >= _notificationDescriptorDatabase.gameNotifications.Count)
			{
				_testNotificationIndex = 0;
			}
		}
	}

	public void ScheduleNotifications()
	{
		if (_systemNotificationService.IsAvailable || _scheduleDebugger.IsAvailable)
		{
			DateTime utcNow = GameDateTime.UtcNow;
			DateTime dateTime = utcNow.Date;
			DateTime endDate = dateTime + TimeSpan.FromDays(30.0);
			_scheduleDebugger.ClearMarkers();
			if (_scheduleDebugger.IsAvailable)
			{
				dateTime = new DateTime(utcNow.Year, utcNow.Month, 1);
				endDate = new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
			}
			Dictionary<DateTime, List<NotificationDescriptor>> conditionsTrueOnDates = FindConditionsTrueOnDates(dateTime, endDate);
			List<List<DatePeriod>> truePeriodsForDescriptors = CalculateTruePeriodsForDescriptors(dateTime, endDate, conditionsTrueOnDates);
			ScheduleNotificationsWithSystem(truePeriodsForDescriptors);
			_scheduleDebugger.AddDebugMarkersForTruePeriods(truePeriodsForDescriptors, _notificationDescriptorDatabase);
		}
	}

	private bool IsNotificationCategoryAllowedByPlayer(NotificationDescriptor descriptor)
	{
		return descriptor.category switch
		{
			NotificationDescriptor.MessageCategory.Challenge => _player.IsChallengeRemindersEnabledSetting, 
			NotificationDescriptor.MessageCategory.Content => _player.IsContentRemindersEnabledSetting, 
			_ => true, 
		};
	}

	private void ScheduleNotificationsWithSystem(List<List<DatePeriod>> truePeriodsForDescriptors)
	{
		_systemNotificationService.RemoveAllScheduledNotifications();
		HashSet<DateTime> hashSet = new HashSet<DateTime>();
		for (int i = 0; i < truePeriodsForDescriptors.Count; i++)
		{
			NotificationDescriptor notificationDescriptor = _notificationDescriptorDatabase.gameNotifications[i];
			SystemNotificationContent content = CreateSystemNotificationContentFromDescriptor(notificationDescriptor);
			List<DatePeriod> list = truePeriodsForDescriptors[i];
			for (int j = 0; j < list.Count; j++)
			{
				DateTime startDate = list[j].startDate;
				if (!hashSet.Contains(startDate))
				{
					DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(startDate, TimeZoneInfo.Local);
					DateTime dateTime2 = TimeZoneInfo.ConvertTimeToUtc(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 9, 30, 0));
					CalendarNotificationTrigger trigger = new CalendarNotificationTrigger
					{
						Year = dateTime2.Year,
						Month = dateTime2.Month,
						Day = dateTime2.Day,
						Hour = dateTime2.Hour,
						Minute = dateTime2.Minute
					};
					_systemNotificationService.ScheduleNotification($"{notificationDescriptor.Id}_{j}", content, trigger);
					hashSet.Add(startDate);
				}
				else
				{
					Log.Info("{0} was not scheduled on {1} as a notification is already present on that day.", notificationDescriptor.Id, startDate);
				}
			}
		}
	}

	private SystemNotificationContent CreateSystemNotificationContentFromDescriptor(NotificationDescriptor descriptor)
	{
		SystemNotificationContent systemNotificationContent = new SystemNotificationContent();
		if (descriptor.messages.Count > 0)
		{
			NotificationDescriptor.GameNotificationMessage gameNotificationMessage = descriptor.messages[0];
			systemNotificationContent.Title = StandaloneLocString.CreateString(_scope, gameNotificationMessage.Title).ToString();
			systemNotificationContent.Body = StandaloneLocString.CreateString(_scope, gameNotificationMessage.Body).ToString();
		}
		else
		{
			Diagnostics.FailAssert("{0} would have been scheduled but had no messages set.", descriptor);
		}
		systemNotificationContent.Badge = 1;
		return systemNotificationContent;
	}

	private List<List<DatePeriod>> CalculateTruePeriodsForDescriptors(DateTime startDate, DateTime endDate, Dictionary<DateTime, List<NotificationDescriptor>> conditionsTrueOnDates)
	{
		List<List<DateTime>> list = new List<List<DateTime>>();
		for (int i = 0; i < _notificationDescriptorDatabase.gameNotifications.Count; i++)
		{
			list.Add(new List<DateTime>());
		}
		for (int j = 0; j < _notificationDescriptorDatabase.gameNotifications.Count; j++)
		{
			NotificationDescriptor item = _notificationDescriptorDatabase.gameNotifications[j];
			for (DateTime dateTime = startDate; dateTime < endDate; dateTime += TimeSpan.FromDays(1.0))
			{
				List<DateTime> list2 = list[j];
				bool flag = conditionsTrueOnDates.ContainsKey(dateTime) && conditionsTrueOnDates[dateTime].Contains(item);
				if (list2.Count % 2 == 0)
				{
					if (flag)
					{
						list2.Add(dateTime);
					}
				}
				else if (!flag)
				{
					list2.Add(dateTime - TimeSpan.FromDays(1.0));
				}
			}
		}
		List<List<DatePeriod>> list3 = new List<List<DatePeriod>>();
		for (int k = 0; k < _notificationDescriptorDatabase.gameNotifications.Count; k++)
		{
			List<DateTime> list4 = list[k];
			list3.Add(new List<DatePeriod>());
			for (int l = 0; l < list4.Count; l += 2)
			{
				DateTime startDate2 = list4[l];
				DateTime? endDate2 = null;
				if (l + 1 < list4.Count)
				{
					endDate2 = list4[l + 1];
				}
				list3[list3.Count - 1].Add(new DatePeriod
				{
					startDate = startDate2,
					endDate = endDate2
				});
			}
		}
		return list3;
	}

	private Dictionary<DateTime, List<NotificationDescriptor>> FindConditionsTrueOnDates(DateTime startDate, DateTime endDate)
	{
		Dictionary<DateTime, List<NotificationDescriptor>> dictionary = new Dictionary<DateTime, List<NotificationDescriptor>>();
		for (DateTime dateTime = startDate; dateTime <= endDate; dateTime += TimeSpan.FromDays(1.0))
		{
			foreach (NotificationDescriptor gameNotification in _notificationDescriptorDatabase.gameNotifications)
			{
				if (gameNotification == null)
				{
					Diagnostics.FailAssert("Found null descriptor in database while scheduling notifications. Is an active notification descriptor set to 'None'?");
				}
				else
				{
					if (!IsNotificationCategoryAllowedByPlayer(gameNotification))
					{
						continue;
					}
					bool flag = true;
					foreach (NotificationBooleanExpression condition in gameNotification.conditions)
					{
						if (!condition.IsTrue(dateTime, _notificationEventSystem))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						if (!dictionary.TryGetValue(dateTime, out var value))
						{
							value = new List<NotificationDescriptor>();
						}
						value.Add(gameNotification);
						dictionary[dateTime] = value;
					}
				}
			}
		}
		return dictionary;
	}
}
