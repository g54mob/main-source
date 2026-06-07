using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 88)]
	internal struct TokenInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_App;

		private IntPtr m_ClientId;

		private IntPtr m_AccountId;

		private IntPtr m_AccessToken;

		private double m_ExpiresIn;

		private IntPtr m_ExpiresAt;

		private AuthTokenType m_AuthType;

		private IntPtr m_RefreshToken;

		private double m_RefreshExpiresIn;

		private IntPtr m_RefreshExpiresAt;

		public string App
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ClientId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EpicAccountId AccountId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string AccessToken
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public double ExpiresIn
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public string ExpiresAt
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AuthTokenType AuthType
		{
			get
			{
				return default(AuthTokenType);
			}
			set
			{
			}
		}

		public string RefreshToken
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public double RefreshExpiresIn
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public string RefreshExpiresAt
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(Token other)
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
