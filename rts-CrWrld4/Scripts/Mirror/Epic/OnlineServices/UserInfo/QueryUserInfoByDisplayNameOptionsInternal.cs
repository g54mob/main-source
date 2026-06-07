using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UserInfo
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct QueryUserInfoByDisplayNameOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_DisplayName;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string DisplayName
		{
			set
			{
			}
		}

		public void Set(QueryUserInfoByDisplayNameOptions other)
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
