using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Friends
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct GetFriendsCountOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public void Set(GetFriendsCountOptions other)
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
