using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct CopyLeaderboardDefinitionByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_LeaderboardIndex;

		public uint LeaderboardIndex
		{
			set
			{
			}
		}

		public void Set(CopyLeaderboardDefinitionByIndexOptions other)
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
