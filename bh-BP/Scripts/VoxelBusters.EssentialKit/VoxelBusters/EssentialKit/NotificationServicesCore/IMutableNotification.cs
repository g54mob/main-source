using System.Collections;

namespace VoxelBusters.EssentialKit.NotificationServicesCore
{
	public interface IMutableNotification : INotification
	{
		void SetTitle(string value);

		void SetSubtitle(string value);

		void SetBody(string value);

		void SetBadge(int value);

		void SetUserInfo(IDictionary value);

		void SetSoundFileName(string value);

		void SetIosProperties(NotificationIosProperties value);

		void SetAndroidProperties(NotificationAndroidProperties value);

		void SetTrigger(INotificationTrigger trigger);

		void SetPriority(NotificationPriority value);
	}
}
