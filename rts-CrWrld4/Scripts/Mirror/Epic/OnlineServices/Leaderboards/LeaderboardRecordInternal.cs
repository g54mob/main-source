using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct LeaderboardRecordInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_UserId;

		private uint m_Rank;

		private int m_Score;

		private IntPtr m_UserDisplayName;

		public ProductUserId UserId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public uint Rank
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public int Score
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string UserDisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(LeaderboardRecord other)
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
