using System;

namespace VoxelBusters.EssentialKit
{
	[Flags]
	public enum NotificationPresentationOptions
	{
		Alert = 1,
		Badge = 2,
		Sound = 4
	}
}
