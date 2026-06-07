using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	public abstract class LeaderboardScoreBase : NativeObjectBase, ILeaderboardScore
	{
		public string LeaderboardId { get; internal set; }

		public string LeaderboardPlatformId { get; internal set; }

		public IPlayer Player => null;

		public long Rank => 0L;

		public long Value => 0L;

		public string FormattedValue => null;

		public DateTime LastReportedDate => default(DateTime);

		public string Tag => null;

		protected LeaderboardScoreBase(string leaderboardId, string leaderboardPlatformId)
		{
		}

		protected LeaderboardScoreBase(string leaderboardPlatformId)
		{
		}

		protected abstract IPlayer GetPlayerInternal();

		protected abstract long GetRankInternal();

		protected abstract long GetValueInternal();

		protected abstract DateTime GetLastReportedDateInternal();

		protected abstract string GetTagInternal();

		public override string ToString()
		{
			return null;
		}
	}
}
