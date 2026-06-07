using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyProductUserExternalAccountByAccountIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		private IntPtr m_AccountId;

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public string AccountId
		{
			set
			{
			}
		}

		public void Set(CopyProductUserExternalAccountByAccountIdOptions other)
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
