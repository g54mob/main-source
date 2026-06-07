using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UserInfo
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct CopyExternalUserInfoByAccountTypeOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		private ExternalAccountType m_AccountType;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public EpicAccountId TargetUserId
		{
			set
			{
			}
		}

		public ExternalAccountType AccountType
		{
			set
			{
			}
		}

		public void Set(CopyExternalUserInfoByAccountTypeOptions other)
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
