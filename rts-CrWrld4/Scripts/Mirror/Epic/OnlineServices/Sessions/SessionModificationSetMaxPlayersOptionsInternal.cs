using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct SessionModificationSetMaxPlayersOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_MaxPlayers;

		public uint MaxPlayers
		{
			set
			{
			}
		}

		public void Set(SessionModificationSetMaxPlayersOptions other)
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
