using System;

namespace VoxelBusters.EssentialKit
{
	[Flags]
	public enum NotificationSettingStatus
	{
		Disabled = 0,
		Enabled = 1,
		NotSupported = 2,
		NotAccessible = 3
	}
}
