using System.Collections;

namespace VoxelBusters.EssentialKit.NotificationServicesCore
{
	internal sealed class NullMutableNotification : NotificationBase, IMutableNotification, INotification
	{
		public NullMutableNotification(string notificationId)
			: base(null)
		{
		}

		private static void LogNotSupported()
		{
		}

		protected override string GetTitleInternal()
		{
			return null;
		}

		protected override string GetSubtitleInternal()
		{
			return null;
		}

		protected override string GetBodyInternal()
		{
			return null;
		}

		protected override int GetBadgeInternal()
		{
			return 0;
		}

		protected override IDictionary GetUserInfoInternal()
		{
			return null;
		}

		protected override string GetSoundFileNameInternal()
		{
			return null;
		}

		protected override INotificationTrigger GetTriggerInternal()
		{
			return null;
		}

		protected override bool GetIsLaunchNotificationInternal()
		{
			return false;
		}

		protected override NotificationIosProperties GetIosPropertiesInternal()
		{
			return null;
		}

		protected override NotificationAndroidProperties GetAndroidPropertiesInternal()
		{
			return null;
		}

		public void SetTitle(string value)
		{
		}

		public void SetSubtitle(string value)
		{
		}

		public void SetBody(string value)
		{
		}

		public void SetBadge(int value)
		{
		}

		public void SetUserInfo(IDictionary value)
		{
		}

		public void SetSoundFileName(string value)
		{
		}

		public void SetIosProperties(NotificationIosProperties value)
		{
		}

		public void SetAndroidProperties(NotificationAndroidProperties value)
		{
		}

		public void SetTrigger(INotificationTrigger trigger)
		{
		}

		public void SetPriority(NotificationPriority value)
		{
		}
	}
}
