using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CredentialsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Token;

		private ExternalCredentialType m_Type;

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

		public ExternalCredentialType Type
		{
			get
			{
				return default(ExternalCredentialType);
			}
			set
			{
			}
		}

		public void Set(Credentials other)
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
