using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	internal struct GetLeaderboardRecordCountOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		public void Set(GetLeaderboardRecordCountOptions other)
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
