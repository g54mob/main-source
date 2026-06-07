using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct LoginOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Credentials;

		private IntPtr m_UserLoginInfo;

		public Credentials Credentials
		{
			set
			{
			}
		}

		public UserLoginInfo UserLoginInfo
		{
			set
			{
			}
		}

		public void Set(LoginOptions other)
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
