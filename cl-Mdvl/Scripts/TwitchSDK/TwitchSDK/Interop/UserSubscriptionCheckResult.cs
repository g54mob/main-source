using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class UserSubscriptionCheckResult : IMarshallable
	{
		internal readonly int TypeCode = -1536148643;

		public string Tier;

		public string GifterLogin;

		public string GifterName;

		public bool IsGift;

		public bool IsSubscribed;

		public override int GetHashCode()
		{
			return ((((13 * 7 + Tier.GetHashCode()) * 7 + GifterLogin.GetHashCode()) * 7 + GifterName.GetHashCode()) * 7 + IsGift.GetHashCode()) * 7 + IsSubscribed.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			UserSubscriptionCheckResult userSubscriptionCheckResult = obj as UserSubscriptionCheckResult;
			if (userSubscriptionCheckResult == null)
			{
				return false;
			}
			if (Tier == userSubscriptionCheckResult.Tier && GifterLogin == userSubscriptionCheckResult.GifterLogin && GifterName == userSubscriptionCheckResult.GifterName && IsGift == userSubscriptionCheckResult.IsGift)
			{
				return IsSubscribed == userSubscriptionCheckResult.IsSubscribed;
			}
			return false;
		}

		public static bool operator ==(UserSubscriptionCheckResult a, UserSubscriptionCheckResult b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(UserSubscriptionCheckResult a, UserSubscriptionCheckResult b)
		{
			return !(a == b);
		}
	}
}
