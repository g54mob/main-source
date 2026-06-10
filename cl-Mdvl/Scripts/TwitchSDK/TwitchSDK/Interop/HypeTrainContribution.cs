using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class HypeTrainContribution : IMarshallable
	{
		internal readonly int TypeCode = 1747825069;

		public string UserId;

		public string UserName;

		public HypeTrainContributionType Type;

		public long Total;

		public override int GetHashCode()
		{
			return (((13 * 7 + UserId.GetHashCode()) * 7 + UserName.GetHashCode()) * 7 + Type.GetHashCode()) * 7 + Total.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			HypeTrainContribution hypeTrainContribution = obj as HypeTrainContribution;
			if (hypeTrainContribution == null)
			{
				return false;
			}
			if (UserId == hypeTrainContribution.UserId && UserName == hypeTrainContribution.UserName && Type == hypeTrainContribution.Type)
			{
				return Total == hypeTrainContribution.Total;
			}
			return false;
		}

		public static bool operator ==(HypeTrainContribution a, HypeTrainContribution b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(HypeTrainContribution a, HypeTrainContribution b)
		{
			return !(a == b);
		}
	}
}
