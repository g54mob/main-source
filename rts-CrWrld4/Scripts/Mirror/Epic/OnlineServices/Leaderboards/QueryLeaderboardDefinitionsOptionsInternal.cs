using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct QueryLeaderboardDefinitionsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private long m_StartTime;

		private long m_EndTime;

		private IntPtr m_LocalUserId;

		public DateTimeOffset? StartTime
		{
			set
			{
			}
		}

		public DateTimeOffset? EndTime
		{
			set
			{
			}
		}

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public void Set(QueryLeaderboardDefinitionsOptions other)
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
