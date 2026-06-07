using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UserInfo
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct CopyExternalUserInfoByAccountIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		private IntPtr m_AccountId;

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

		public string AccountId
		{
			set
			{
			}
		}

		public void Set(CopyExternalUserInfoByAccountIdOptions other)
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
