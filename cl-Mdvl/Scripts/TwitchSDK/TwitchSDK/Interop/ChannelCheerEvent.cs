using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class ChannelCheerEvent : IMarshallable
	{
		internal readonly int TypeCode = -1586617571;

		public bool IsAnonymous;

		public string UserId;

		public string UserDisplayName;

		public string Message;

		public long Bits;

		public override int GetHashCode()
		{
			return ((((13 * 7 + IsAnonymous.GetHashCode()) * 7 + UserId.GetHashCode()) * 7 + UserDisplayName.GetHashCode()) * 7 + Message.GetHashCode()) * 7 + Bits.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ChannelCheerEvent channelCheerEvent = obj as ChannelCheerEvent;
			if (channelCheerEvent == null)
			{
				return false;
			}
			if (IsAnonymous == channelCheerEvent.IsAnonymous && UserId == channelCheerEvent.UserId && UserDisplayName == channelCheerEvent.UserDisplayName && Message == channelCheerEvent.Message)
			{
				return Bits == channelCheerEvent.Bits;
			}
			return false;
		}

		public static bool operator ==(ChannelCheerEvent a, ChannelCheerEvent b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(ChannelCheerEvent a, ChannelCheerEvent b)
		{
			return !(a == b);
		}
	}
}
