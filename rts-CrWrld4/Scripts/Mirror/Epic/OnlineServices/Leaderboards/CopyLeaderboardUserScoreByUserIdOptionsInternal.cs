using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyLeaderboardUserScoreByUserIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_UserId;

		private IntPtr m_StatName;

		public ProductUserId UserId
		{
			set
			{
			}
		}

		public string StatName
		{
			set
			{
			}
		}

		public void Set(CopyLeaderboardUserScoreByUserIdOptions other)
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
