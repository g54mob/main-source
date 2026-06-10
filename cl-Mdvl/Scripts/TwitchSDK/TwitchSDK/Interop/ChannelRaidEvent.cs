using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class ChannelRaidEvent : IMarshallable
	{
		internal readonly int TypeCode = 1840358796;

		public string FromBroadcasterId;

		public string FromBroadcasterName;

		public string ToBroadcasterId;

		public string ToBroadcasterName;

		public long Viewers;

		public override int GetHashCode()
		{
			return ((((13 * 7 + FromBroadcasterId.GetHashCode()) * 7 + FromBroadcasterName.GetHashCode()) * 7 + ToBroadcasterId.GetHashCode()) * 7 + ToBroadcasterName.GetHashCode()) * 7 + Viewers.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ChannelRaidEvent channelRaidEvent = obj as ChannelRaidEvent;
			if (channelRaidEvent == null)
			{
				return false;
			}
			if (FromBroadcasterId == channelRaidEvent.FromBroadcasterId && FromBroadcasterName == channelRaidEvent.FromBroadcasterName && ToBroadcasterId == channelRaidEvent.ToBroadcasterId && ToBroadcasterName == channelRaidEvent.ToBroadcasterName)
			{
				return Viewers == channelRaidEvent.Viewers;
			}
			return false;
		}

		public static bool operator ==(ChannelRaidEvent a, ChannelRaidEvent b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(ChannelRaidEvent a, ChannelRaidEvent b)
		{
			return !(a == b);
		}
	}
}
