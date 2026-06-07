using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	public struct LeaderboardUGCSet
	{
		public LeaderboardUGCSet_t data;

		public EResult Result => data.m_eResult;

		public LeaderboardData Leaderboard => data.m_hSteamLeaderboard;

		public static implicit operator LeaderboardUGCSet(LeaderboardUGCSet_t native)
		{
			return new LeaderboardUGCSet
			{
				data = native
			};
		}

		public static implicit operator LeaderboardUGCSet_t(LeaderboardUGCSet heathen)
		{
			return heathen.data;
		}
	}
}
