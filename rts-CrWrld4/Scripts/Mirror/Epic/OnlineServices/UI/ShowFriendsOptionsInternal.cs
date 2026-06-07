using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UI
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct ShowFriendsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public void Set(ShowFriendsOptions other)
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
