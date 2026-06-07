using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Platform
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct ClientCredentialsInternal : ISettable, IDisposable
	{
		private IntPtr m_ClientId;

		private IntPtr m_ClientSecret;

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

		public string ClientSecret
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(ClientCredentials other)
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
