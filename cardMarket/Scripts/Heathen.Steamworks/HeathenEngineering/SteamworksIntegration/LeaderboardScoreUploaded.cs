using System;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct LeaderboardScoreUploaded
	{
		public LeaderboardScoreUploaded_t data;

		public readonly bool Success => data.m_bSuccess != 0;

		public readonly bool ScoreChanged => data.m_bScoreChanged != 0;

		public readonly LeaderboardData Leaderboard => data.m_hSteamLeaderboard;

		public readonly int Score => data.m_nScore;

		public readonly int GlobalRankNew => data.m_nGlobalRankNew;

		public readonly int GlobalRankPrevious => data.m_nGlobalRankPrevious;

		public static implicit operator LeaderboardScoreUploaded(LeaderboardScoreUploaded_t native)
		{
			return new LeaderboardScoreUploaded
			{
				data = native
			};
		}

		public static implicit operator LeaderboardScoreUploaded_t(LeaderboardScoreUploaded heathen)
		{
			return heathen.data;
		}
	}
}
