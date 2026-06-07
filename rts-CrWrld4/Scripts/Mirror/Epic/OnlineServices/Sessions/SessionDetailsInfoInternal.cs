using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct SessionDetailsInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionId;

		private IntPtr m_HostAddress;

		private uint m_NumOpenPublicConnections;

		private IntPtr m_Settings;

		public string SessionId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string HostAddress
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public uint NumOpenPublicConnections
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public SessionDetailsSettings Settings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(SessionDetailsInfo other)
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
