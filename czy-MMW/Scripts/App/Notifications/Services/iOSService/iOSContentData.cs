using System;
using System.Runtime.InteropServices;
using Notifications.Triggers;

namespace Notifications.Services.iOSService
{
	public class iOSContentData
	{
		public struct NotificationContentData
		{
			public string identifier;

			public string title;

			public string body;

			public int badge;

			public string subtitle;

			public string categoryIdentifier;

			public string threadIdentifier;

			public string data;

			public bool showInForeground;

			public int showInForegroundPresentationOptions;
		}

		public struct TimeIntervalTriggerData
		{
			public int timeIntervalSeconds;

			public bool repeats;
		}

		public struct CalendarTriggerData
		{
			public int year;

			public int month;

			public int day;

			public int hour;

			public int minute;

			public int second;
		}

		public const int InvalidCalendarDate = -1;

		internal static NotificationContentData ToContentData(string identifier, SystemNotificationContent systemNotificationContent)
		{
			return new NotificationContentData
			{
				identifier = identifier,
				title = systemNotificationContent.Title,
				body = systemNotificationContent.Body,
				badge = systemNotificationContent.Badge,
				subtitle = systemNotificationContent.Subtitle
			};
		}

		internal static CalendarTriggerData ToContentData(CalendarNotificationTrigger calendarNotificationTrigger)
		{
			return new CalendarTriggerData
			{
				year = (calendarNotificationTrigger.Year ?? (-1)),
				month = (calendarNotificationTrigger.Month ?? (-1)),
				day = (calendarNotificationTrigger.Day ?? (-1)),
				hour = (calendarNotificationTrigger.Hour ?? (-1)),
				minute = (calendarNotificationTrigger.Minute ?? (-1)),
				second = (calendarNotificationTrigger.Second ?? (-1))
			};
		}

		internal static TimeIntervalTriggerData ToContentData(TimeIntervalNotificationTrigger calendarNotificationTrigger)
		{
			return new TimeIntervalTriggerData
			{
				timeIntervalSeconds = (int)calendarNotificationTrigger.TimeInterval.TotalSeconds,
				repeats = calendarNotificationTrigger.Repeats
			};
		}

		internal static IntPtr ToIntPtr<T>(T data)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(data));
			Marshal.StructureToPtr(data, intPtr, fDeleteOld: false);
			return intPtr;
		}
	}
}
