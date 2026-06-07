using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct PinGrantInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_UserCode;

		private IntPtr m_VerificationURI;

		private int m_ExpiresIn;

		private IntPtr m_VerificationURIComplete;

		public string UserCode
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string VerificationURI
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int ExpiresIn
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string VerificationURIComplete
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(PinGrantInfo other)
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
