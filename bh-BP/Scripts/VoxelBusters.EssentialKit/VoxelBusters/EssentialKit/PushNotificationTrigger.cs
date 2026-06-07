using System;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public sealed class PushNotificationTrigger : INotificationTrigger
	{
		public bool Repeats { get; private set; }
	}
}
