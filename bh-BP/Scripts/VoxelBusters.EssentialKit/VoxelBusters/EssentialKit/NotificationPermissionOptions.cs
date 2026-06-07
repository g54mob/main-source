using System;

namespace VoxelBusters.EssentialKit
{
	[Flags]
	public enum NotificationPermissionOptions
	{
		None = 0,
		Badge = 1,
		Sound = 2,
		Alert = 4,
		CarPlay = 8,
		CriticalAlert = 0x10,
		ProvidesAppNotificationSettings = 0x20,
		Provisional = 0x40,
		Announcement = 0x80,
		ExactTiming = 0x100,
		All = 0x1FF
	}
}
