using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyProductUserExternalAccountByAccountTypeOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		private ExternalAccountType m_AccountIdType;

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public ExternalAccountType AccountIdType
		{
			set
			{
			}
		}

		public void Set(CopyProductUserExternalAccountByAccountTypeOptions other)
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
