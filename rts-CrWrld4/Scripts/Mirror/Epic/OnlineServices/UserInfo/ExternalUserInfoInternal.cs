using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UserInfo
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct ExternalUserInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private ExternalAccountType m_AccountType;

		private IntPtr m_AccountId;

		private IntPtr m_DisplayName;

		public ExternalAccountType AccountType
		{
			get
			{
				return default(ExternalAccountType);
			}
			set
			{
			}
		}

		public string AccountId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string DisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(ExternalUserInfo other)
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
