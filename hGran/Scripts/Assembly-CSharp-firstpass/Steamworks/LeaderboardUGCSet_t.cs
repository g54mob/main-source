using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(1111)]
	public struct LeaderboardUGCSet_t
	{
		public const int k_iCallback = 1111;

		public EResult m_eResult;

		public SteamLeaderboard_t m_hSteamLeaderboard;
	}
}
