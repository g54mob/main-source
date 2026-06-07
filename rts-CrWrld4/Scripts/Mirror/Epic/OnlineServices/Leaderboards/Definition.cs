using System;

namespace Epic.OnlineServices.Leaderboards
{
	public class Definition : ISettable
	{
		public string LeaderboardId { get; set; }

		public string StatName { get; set; }

		public LeaderboardAggregation Aggregation { get; set; }

		public DateTimeOffset? StartTime { get; set; }

		public DateTimeOffset? EndTime { get; set; }

		internal void Set(DefinitionInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
