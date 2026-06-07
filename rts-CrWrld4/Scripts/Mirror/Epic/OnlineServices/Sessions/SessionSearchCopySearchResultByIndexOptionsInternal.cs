using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct SessionSearchCopySearchResultByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_SessionIndex;

		public uint SessionIndex
		{
			set
			{
			}
		}

		public void Set(SessionSearchCopySearchResultByIndexOptions other)
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
