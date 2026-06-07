using System.Collections;

namespace VoxelBusters.EssentialKit
{
	public interface INotification
	{
		string Id { get; }

		string Title { get; }

		string Subtitle { get; }

		string Body { get; }

		int Badge { get; }

		IDictionary UserInfo { get; }

		string SoundFileName { get; }

		NotificationTriggerType TriggerType { get; }

		INotificationTrigger Trigger { get; }

		bool IsLaunchNotification { get; }

		NotificationIosProperties IosProperties { get; }

		NotificationAndroidProperties AndroidProperties { get; }
	}
}
