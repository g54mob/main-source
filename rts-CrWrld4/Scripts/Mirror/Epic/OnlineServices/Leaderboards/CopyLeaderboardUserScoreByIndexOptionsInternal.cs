using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct CopyLeaderboardUserScoreByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_LeaderboardUserScoreIndex;

		private IntPtr m_StatName;

		public uint LeaderboardUserScoreIndex
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

		public void Set(CopyLeaderboardUserScoreByIndexOptions other)
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
