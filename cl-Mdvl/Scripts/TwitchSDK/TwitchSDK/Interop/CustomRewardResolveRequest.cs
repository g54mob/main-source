using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class CustomRewardResolveRequest : IMarshallable
	{
		internal readonly int TypeCode = -1152625179;

		public string RedemptionId;

		public string CustomRewardId;

		public string BroadcasterId;

		public CustomRewardRedemptionState Resolution;

		public override int GetHashCode()
		{
			return (((13 * 7 + RedemptionId.GetHashCode()) * 7 + CustomRewardId.GetHashCode()) * 7 + BroadcasterId.GetHashCode()) * 7 + Resolution.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			CustomRewardResolveRequest customRewardResolveRequest = obj as CustomRewardResolveRequest;
			if (customRewardResolveRequest == null)
			{
				return false;
			}
			if (RedemptionId == customRewardResolveRequest.RedemptionId && CustomRewardId == customRewardResolveRequest.CustomRewardId && BroadcasterId == customRewardResolveRequest.BroadcasterId)
			{
				return Resolution == customRewardResolveRequest.Resolution;
			}
			return false;
		}

		public static bool operator ==(CustomRewardResolveRequest a, CustomRewardResolveRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(CustomRewardResolveRequest a, CustomRewardResolveRequest b)
		{
			return !(a == b);
		}
	}
}
