using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UserInfo
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct UserInfoDataInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_UserId;

		private IntPtr m_Country;

		private IntPtr m_DisplayName;

		private IntPtr m_PreferredLanguage;

		private IntPtr m_Nickname;

		public EpicAccountId UserId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Country
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

		public string PreferredLanguage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Nickname
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(UserInfoData other)
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
