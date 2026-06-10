using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class BitsLeaderboard : IMarshallable
	{
		internal readonly int TypeCode = -1209729142;

		public BitsLeaderboardEntry[] Data;

		public string StartedAt;

		public string EndedAt;

		public override int GetHashCode()
		{
			return ((13 * 7 + Data.GetHashCode()) * 7 + StartedAt.GetHashCode()) * 7 + EndedAt.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			BitsLeaderboard bitsLeaderboard = obj as BitsLeaderboard;
			if (bitsLeaderboard == null)
			{
				return false;
			}
			if (Data == bitsLeaderboard.Data && StartedAt == bitsLeaderboard.StartedAt)
			{
				return EndedAt == bitsLeaderboard.EndedAt;
			}
			return false;
		}

		public static bool operator ==(BitsLeaderboard a, BitsLeaderboard b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(BitsLeaderboard a, BitsLeaderboard b)
		{
			return !(a == b);
		}
	}
}
