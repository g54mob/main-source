using System.Collections.Generic;
using VoxelBusters.CoreLibrary.NativePlugins;
using VoxelBusters.EssentialKit.NotificationServicesCore;

namespace VoxelBusters.EssentialKit
{
	public class NotificationBuilder
	{
		private IMutableNotification m_notification;

		private NotificationBuilder()
		{
		}

		public static NotificationBuilder CreateNotification(string notificationId)
		{
			return null;
		}

		public NotificationBuilder SetTitle(string value)
		{
			return null;
		}

		public NotificationBuilder SetSubtitle(string value)
		{
			return null;
		}

		public NotificationBuilder SetBody(string value)
		{
			return null;
		}

		public NotificationBuilder SetBadge(int value)
		{
			return null;
		}

		public NotificationBuilder SetUserInfo(Dictionary<string, string> value)
		{
			return null;
		}

		public NotificationBuilder SetUserInfo(params KeyValuePair<string, string>[] values)
		{
			return null;
		}

		public NotificationBuilder SetSoundFileName(string value)
		{
			return null;
		}

		public NotificationBuilder SetIosProperties(NotificationIosProperties value)
		{
			return null;
		}

		public NotificationBuilder SetAndroidProperties(NotificationAndroidProperties value)
		{
			return null;
		}

		public NotificationBuilder SetTimeIntervalNotificationTrigger(double interval, bool repeats = false)
		{
			return null;
		}

		public NotificationBuilder SetCalendarNotificationTrigger(DateComponents dateComponent, bool repeats = false)
		{
			return null;
		}

		public NotificationBuilder SetLocationNotificationTrigger(CircularRegion region, bool notifyOnEntry, bool notifyOnExit, bool repeats = false)
		{
			return null;
		}

		public NotificationBuilder SetPriority(NotificationPriority priority)
		{
			return null;
		}

		public INotification Create()
		{
			return null;
		}
	}
}
