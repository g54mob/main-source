using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class CustomRewardList : IMarshallable
	{
		internal readonly int TypeCode = -67112796;

		public CustomRewardDefinition[] Rewards;

		public override int GetHashCode()
		{
			return 13 * 7 + Rewards.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			CustomRewardList customRewardList = obj as CustomRewardList;
			if (customRewardList == null)
			{
				return false;
			}
			return Rewards == customRewardList.Rewards;
		}

		public static bool operator ==(CustomRewardList a, CustomRewardList b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(CustomRewardList a, CustomRewardList b)
		{
			return !(a == b);
		}
	}
}
