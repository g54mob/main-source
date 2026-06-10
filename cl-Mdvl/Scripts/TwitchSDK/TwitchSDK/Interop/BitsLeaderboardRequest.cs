using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class BitsLeaderboardRequest : IMarshallable
	{
		internal readonly int TypeCode = 794647764;

		public int Count;

		public string Period;

		public string StartedAt;

		public string UserId;

		public override int GetHashCode()
		{
			return (((13 * 7 + Count.GetHashCode()) * 7 + Period.GetHashCode()) * 7 + StartedAt.GetHashCode()) * 7 + UserId.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			BitsLeaderboardRequest bitsLeaderboardRequest = obj as BitsLeaderboardRequest;
			if (bitsLeaderboardRequest == null)
			{
				return false;
			}
			if (Count == bitsLeaderboardRequest.Count && Period == bitsLeaderboardRequest.Period && StartedAt == bitsLeaderboardRequest.StartedAt)
			{
				return UserId == bitsLeaderboardRequest.UserId;
			}
			return false;
		}

		public static bool operator ==(BitsLeaderboardRequest a, BitsLeaderboardRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(BitsLeaderboardRequest a, BitsLeaderboardRequest b)
		{
			return !(a == b);
		}
	}
}
