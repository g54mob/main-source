using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct LobbySearchSetMaxResultsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_MaxResults;

		public uint MaxResults
		{
			set
			{
			}
		}

		public void Set(LobbySearchSetMaxResultsOptions other)
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
