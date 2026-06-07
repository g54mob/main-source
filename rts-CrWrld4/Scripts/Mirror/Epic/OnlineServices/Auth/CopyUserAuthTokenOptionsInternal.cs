using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	internal struct CopyUserAuthTokenOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		public void Set(CopyUserAuthTokenOptions other)
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
