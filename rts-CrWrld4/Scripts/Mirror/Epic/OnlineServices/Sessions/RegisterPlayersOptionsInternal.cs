using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct RegisterPlayersOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionName;

		private IntPtr m_PlayersToRegister;

		private uint m_PlayersToRegisterCount;

		public string SessionName
		{
			set
			{
			}
		}

		public ProductUserId[] PlayersToRegister
		{
			set
			{
			}
		}

		public void Set(RegisterPlayersOptions other)
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
