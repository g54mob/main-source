using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class CustomRewardEvent : IMarshallable
	{
		internal readonly int TypeCode = -800396378;

		public string RedemptionId;

		public string BroadcasterId;

		public string RedeemerId;

		public string BroadcasterName;

		public string RedeemerName;

		public string UserInput;

		public CustomRewardRedemptionState Status;

		public string CustomRewardId;

		public string CustomRewardTitle;

		public long CustomRewardCost;

		public string CustomRewardPrompt;

		public string RedeemedAt;

		public override int GetHashCode()
		{
			return (((((((((((13 * 7 + RedemptionId.GetHashCode()) * 7 + BroadcasterId.GetHashCode()) * 7 + RedeemerId.GetHashCode()) * 7 + BroadcasterName.GetHashCode()) * 7 + RedeemerName.GetHashCode()) * 7 + UserInput.GetHashCode()) * 7 + Status.GetHashCode()) * 7 + CustomRewardId.GetHashCode()) * 7 + CustomRewardTitle.GetHashCode()) * 7 + CustomRewardCost.GetHashCode()) * 7 + CustomRewardPrompt.GetHashCode()) * 7 + RedeemedAt.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			CustomRewardEvent customRewardEvent = obj as CustomRewardEvent;
			if (customRewardEvent == null)
			{
				return false;
			}
			if (RedemptionId == customRewardEvent.RedemptionId && BroadcasterId == customRewardEvent.BroadcasterId && RedeemerId == customRewardEvent.RedeemerId && BroadcasterName == customRewardEvent.BroadcasterName && RedeemerName == customRewardEvent.RedeemerName && UserInput == customRewardEvent.UserInput && Status == customRewardEvent.Status && CustomRewardId == customRewardEvent.CustomRewardId && CustomRewardTitle == customRewardEvent.CustomRewardTitle && CustomRewardCost == customRewardEvent.CustomRewardCost && CustomRewardPrompt == customRewardEvent.CustomRewardPrompt)
			{
				return RedeemedAt == customRewardEvent.RedeemedAt;
			}
			return false;
		}

		public static bool operator ==(CustomRewardEvent a, CustomRewardEvent b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(CustomRewardEvent a, CustomRewardEvent b)
		{
			return !(a == b);
		}
	}
}
