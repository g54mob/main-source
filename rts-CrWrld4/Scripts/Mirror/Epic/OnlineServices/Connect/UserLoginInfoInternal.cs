using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct UserLoginInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_DisplayName;

		public string DisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(UserLoginInfo other)
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
