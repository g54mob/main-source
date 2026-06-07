using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct QueryLeaderboardRanksOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LeaderboardId;

		private IntPtr m_LocalUserId;

		public string LeaderboardId
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

		public void Set(QueryLeaderboardRanksOptions other)
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
