using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct VerifyUserAuthOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_AuthToken;

		public Token AuthToken
		{
			set
			{
			}
		}

		public void Set(VerifyUserAuthOptions other)
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
