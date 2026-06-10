using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class ChannelSubscribeEvent : IMarshallable
	{
		internal readonly int TypeCode = 1666538230;

		public string UserId;

		public string UserLogin;

		public string UserDisplayName;

		public string Tier;

		public bool IsGift;

		public int CumulativeMonths;

		public int StreakMonths;

		public int DurationMonths;

		public override int GetHashCode()
		{
			return (((((((13 * 7 + UserId.GetHashCode()) * 7 + UserLogin.GetHashCode()) * 7 + UserDisplayName.GetHashCode()) * 7 + Tier.GetHashCode()) * 7 + IsGift.GetHashCode()) * 7 + CumulativeMonths.GetHashCode()) * 7 + StreakMonths.GetHashCode()) * 7 + DurationMonths.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ChannelSubscribeEvent channelSubscribeEvent = obj as ChannelSubscribeEvent;
			if (channelSubscribeEvent == null)
			{
				return false;
			}
			if (UserId == channelSubscribeEvent.UserId && UserLogin == channelSubscribeEvent.UserLogin && UserDisplayName == channelSubscribeEvent.UserDisplayName && Tier == channelSubscribeEvent.Tier && IsGift == channelSubscribeEvent.IsGift && CumulativeMonths == channelSubscribeEvent.CumulativeMonths && StreakMonths == channelSubscribeEvent.StreakMonths)
			{
				return DurationMonths == channelSubscribeEvent.DurationMonths;
			}
			return false;
		}

		public static bool operator ==(ChannelSubscribeEvent a, ChannelSubscribeEvent b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(ChannelSubscribeEvent a, ChannelSubscribeEvent b)
		{
			return !(a == b);
		}
	}
}
