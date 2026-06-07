using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct ActiveSessionGetRegisteredPlayerByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_PlayerIndex;

		public uint PlayerIndex
		{
			set
			{
			}
		}

		public void Set(ActiveSessionGetRegisteredPlayerByIndexOptions other)
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
