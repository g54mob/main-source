using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct UnregisterPlayersOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionName;

		private IntPtr m_PlayersToUnregister;

		private uint m_PlayersToUnregisterCount;

		public string SessionName
		{
			set
			{
			}
		}

		public ProductUserId[] PlayersToUnregister
		{
			set
			{
			}
		}

		public void Set(UnregisterPlayersOptions other)
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
