using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct AccountFeatureRestrictedInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_VerificationURI;

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

		public void Set(AccountFeatureRestrictedInfo other)
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
