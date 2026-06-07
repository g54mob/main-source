using System;

namespace VoxelBusters.EssentialKit
{
	[Flags]
	public enum NotificationTriggerType
	{
		Undefined = 0,
		TimeInterval = 1,
		Calendar = 2,
		Location = 4,
		PushNotification = 8,
		LocalNotification = 7
	}
}
