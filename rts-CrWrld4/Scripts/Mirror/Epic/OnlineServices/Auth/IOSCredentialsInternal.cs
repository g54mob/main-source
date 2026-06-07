using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct IOSCredentialsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Id;

		private IntPtr m_Token;

		private LoginCredentialType m_Type;

		private IntPtr m_SystemAuthCredentialsOptions;

		private ExternalCredentialType m_ExternalType;

		public string Id
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Token
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LoginCredentialType Type
		{
			get
			{
				return default(LoginCredentialType);
			}
			set
			{
			}
		}

		public IOSCredentialsSystemAuthCredentialsOptions SystemAuthCredentialsOptions
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExternalCredentialType ExternalType
		{
			get
			{
				return default(ExternalCredentialType);
			}
			set
			{
			}
		}

		public void Set(IOSCredentials other)
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
