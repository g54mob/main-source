using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct SessionSearchSetMaxResultsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_MaxSearchResults;

		public uint MaxSearchResults
		{
			set
			{
			}
		}

		public void Set(SessionSearchSetMaxResultsOptions other)
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
