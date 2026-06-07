using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct UserScoresQueryStatInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_StatName;

		private LeaderboardAggregation m_Aggregation;

		public string StatName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LeaderboardAggregation Aggregation
		{
			get
			{
				return default(LeaderboardAggregation);
			}
			set
			{
			}
		}

		public void Set(UserScoresQueryStatInfo other)
		{
		}

		public void Set(object other)
		{
		}

		public void Dispose()
		{
		}
	}
}
