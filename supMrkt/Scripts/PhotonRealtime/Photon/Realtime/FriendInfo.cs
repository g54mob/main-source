using System;

namespace Photon.Realtime
{
	public class FriendInfo
	{
		[Obsolete("Use UserId.")]
		public string Name => null;

		public string UserId { get; protected internal set; }

		public bool IsOnline { get; protected internal set; }

		public string Room { get; protected internal set; }

		public bool IsInRoom => false;

		public override string ToString()
		{
			return null;
		}
	}
}
