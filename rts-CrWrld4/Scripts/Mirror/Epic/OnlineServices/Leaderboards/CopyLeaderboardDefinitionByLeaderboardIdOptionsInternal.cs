using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct CopyLeaderboardDefinitionByLeaderboardIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LeaderboardId;

		public string LeaderboardId
		{
			set
			{
			}
		}

		public void Set(CopyLeaderboardDefinitionByLeaderboardIdOptions other)
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
