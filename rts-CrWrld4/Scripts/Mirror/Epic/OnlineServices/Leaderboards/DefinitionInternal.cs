using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct DefinitionInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LeaderboardId;

		private IntPtr m_StatName;

		private LeaderboardAggregation m_Aggregation;

		private long m_StartTime;

		private long m_EndTime;

		public string LeaderboardId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public DateTimeOffset? StartTime
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DateTimeOffset? EndTime
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(Definition other)
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
