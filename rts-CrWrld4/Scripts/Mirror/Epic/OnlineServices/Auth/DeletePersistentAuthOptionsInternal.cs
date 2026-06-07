using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct DeletePersistentAuthOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_RefreshToken;

		public string RefreshToken
		{
			set
			{
			}
		}

		public void Set(DeletePersistentAuthOptions other)
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
