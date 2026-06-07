using System;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	internal sealed class NullLeaderboardScore : LeaderboardScoreBase
	{
		public NullLeaderboardScore(string leaderboardId, string leaderboardPlatformId)
			: base(null, null)
		{
		}

		private static void LogNotSupported()
		{
		}

		protected override IPlayer GetPlayerInternal()
		{
			return null;
		}

		protected override long GetRankInternal()
		{
			return 0L;
		}

		protected override long GetValueInternal()
		{
			return 0L;
		}

		protected override DateTime GetLastReportedDateInternal()
		{
			return default(DateTime);
		}

		protected override string GetTagInternal()
		{
			return null;
		}
	}
}
