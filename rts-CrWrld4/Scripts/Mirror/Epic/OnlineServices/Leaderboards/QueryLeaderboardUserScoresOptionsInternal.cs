using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 64)]
	internal struct QueryLeaderboardUserScoresOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_UserIds;

		private uint m_UserIdsCount;

		private IntPtr m_StatInfo;

		private uint m_StatInfoCount;

		private long m_StartTime;

		private long m_EndTime;

		private IntPtr m_LocalUserId;

		public ProductUserId[] UserIds
		{
			set
			{
			}
		}

		public UserScoresQueryStatInfo[] StatInfo
		{
			set
			{
			}
		}

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

		public void Set(QueryLeaderboardUserScoresOptions other)
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
