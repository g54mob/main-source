using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct SessionModificationSetHostAddressOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_HostAddress;

		public string HostAddress
		{
			set
			{
			}
		}

		public void Set(SessionModificationSetHostAddressOptions other)
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
