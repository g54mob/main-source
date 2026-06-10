using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class BitsLeaderboardEntry : IMarshallable
	{
		internal readonly int TypeCode = -432329023;

		public string UserId;

		public string UserName;

		public long Rank;

		public long Score;

		public override int GetHashCode()
		{
			return (((13 * 7 + UserId.GetHashCode()) * 7 + UserName.GetHashCode()) * 7 + Rank.GetHashCode()) * 7 + Score.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			BitsLeaderboardEntry bitsLeaderboardEntry = obj as BitsLeaderboardEntry;
			if (bitsLeaderboardEntry == null)
			{
				return false;
			}
			if (UserId == bitsLeaderboardEntry.UserId && UserName == bitsLeaderboardEntry.UserName && Rank == bitsLeaderboardEntry.Rank)
			{
				return Score == bitsLeaderboardEntry.Score;
			}
			return false;
		}

		public static bool operator ==(BitsLeaderboardEntry a, BitsLeaderboardEntry b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(BitsLeaderboardEntry a, BitsLeaderboardEntry b)
		{
			return !(a == b);
		}
	}
}
