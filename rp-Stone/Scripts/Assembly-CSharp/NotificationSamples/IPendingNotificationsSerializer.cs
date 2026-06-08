using System.Collections.Generic;

namespace NotificationSamples
{
	public interface IPendingNotificationsSerializer
	{
		void Serialize(IList<PendingNotification> notifications);

		IList<IGameNotification> Deserialize(IGameNotificationsPlatform platform);
	}
}
