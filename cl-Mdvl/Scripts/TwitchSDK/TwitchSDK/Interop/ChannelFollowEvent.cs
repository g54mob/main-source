using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class ChannelFollowEvent : IMarshallable
	{
		internal readonly int TypeCode = -895127529;

		public string UserId;

		public string UserDisplayName;

		public string FollowedAt;

		public override int GetHashCode()
		{
			return ((13 * 7 + UserId.GetHashCode()) * 7 + UserDisplayName.GetHashCode()) * 7 + FollowedAt.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ChannelFollowEvent channelFollowEvent = obj as ChannelFollowEvent;
			if (channelFollowEvent == null)
			{
				return false;
			}
			if (UserId == channelFollowEvent.UserId && UserDisplayName == channelFollowEvent.UserDisplayName)
			{
				return FollowedAt == channelFollowEvent.FollowedAt;
			}
			return false;
		}

		public static bool operator ==(ChannelFollowEvent a, ChannelFollowEvent b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(ChannelFollowEvent a, ChannelFollowEvent b)
		{
			return !(a == b);
		}
	}
}
